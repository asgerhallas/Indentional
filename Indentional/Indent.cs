using System;
using System.Text;

namespace Indentional
{
    public static class Indentional
    {
        public static string _(string s) => Indent(s);

        public static string _(string outputNewLine, string s) => Indent(outputNewLine, s);
        
        public static string Indent(string s) => _(Environment.NewLine, s);

        public static string Indent(string outputNewLine, string s)
        {
            var state = new ParserState(State.BeginText, 0, ReadOnlySpan<char>.Empty);
            var result = new StringBuilder();

            var pos = 0;
            while (state.State != State.EndText)
            {
                state = Parse(in state, ReadLine(s, ref pos), pos >= s.Length);
                result.Append(state.Output);
            }

            return result.Replace(Environment.NewLine, outputNewLine).ToString();
        }

        public static ReadOnlySpan<char> ReadLine(string str, ref int pos)
        {
            int i = pos;
            var length = str.Length;
            while (i < length)
            {
                char ch = str[i];
                if (ch == '\r' || ch == '\n')
                {
                    ReadOnlySpan<char> result = str[pos..i];
                    pos = i + 1;
                    if (ch == '\r' && pos < length && str[pos] == '\n') pos++;
                    return result;
                }
                i++;
            }
            if (i > pos)
            {
                ReadOnlySpan<char> result = str[pos..i];
                pos = i;
                return result;
            }
            return null;
        }

        static ParserState Parse(in ParserState state, in ReadOnlySpan<char> line, bool lastLine) => 
            line != null
                ? lastLine
                    ? ParseLine(in state, line)
                    : ParseLine(in state, line.TrimEnd())
                : state.Next(State.EndText);

        static readonly string doubleNewLine = $"{Environment.NewLine}{Environment.NewLine}";

        static ParserState ParseLine(in ParserState state, in ReadOnlySpan<char> line) =>
            IsLineBreak(line)
                ? state.State switch 
                {
                    State.BeginText => state.Next(State.BeginTextWithLineBreak),
                    State.BeginTextWithLine => state.Next(State.Block, doubleNewLine),
                    State.BeginTextWithLineBreak => state.Next(State.BeginTextWithLineBreak),
                    State.Line => state.Next(State.Block, doubleNewLine),
                    State.Block => state.Next(State.Block),
                    _ => state.Next(State.EndText)
                } : state.State switch
                {
                    State.BeginText => state.Next(State.BeginTextWithLine, line),
                    State.BeginTextWithLine => Indent(state, line, " "),
                    State.BeginTextWithLineBreak => Indent(state, line, ReadOnlySpan<char>.Empty),
                    State.Line => state.Next(State.Line, string.Concat(" ", IndentLine(state.Identation, line))),
                    State.Block => state.Next(State.Line, IndentLine(state.Identation, line).ToString()),
                    _ => state.Next(State.EndText)
                };

        static ParserState Indent(in ParserState state, in ReadOnlySpan<char> line, in ReadOnlySpan<char> prepend)
        {
            var indent = line.Length - line.TrimStart().Length;
            return state.Next(State.Line, indent, string.Concat(prepend, IndentLine(indent, line)));
        }

        static bool IsLineBreak(ReadOnlySpan<char> line) => line.Trim().Length == 0;

        static ReadOnlySpan<char> IndentLine(in int identation, ReadOnlySpan<char> line) => line[Math.Min(identation, line.Length)..];
    }
}