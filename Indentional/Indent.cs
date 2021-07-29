using Microsoft.Extensions.ObjectPool;
using System;
using System.Text;

namespace Indentional
{
    public static class Indentional
    {
        public static string _(string s) => Indent(s);

        public static string _(string outputNewLine, string s) => Indent(outputNewLine, s);

        public static string Indent(string s) => Indent(Environment.NewLine, s);

        public static string Indent(string outputNewLine, string s)
        {
            // No more bleeding eyes.. except for the devs
#if NETSTANDARD2_0
            return Standard2.IndentionalOriginal.Indent(outputNewLine, s);
#else
            return IndentInternal(outputNewLine, s);
#endif
        }

#if !NETSTANDARD2_0
        private static string IndentInternal(string outputNewLine, string s)
        {
            var state = new ParserState(State.BeginText, 0, ReadOnlySpan<char>.Empty);
            var strBuilder = new StringBuilder(s.Length);

            var outputNewLineX2 = outputNewLine + outputNewLine;

            var pos = 0;
            while (state.State != State.EndText)
            {
                state = Parse(in state, ReadLine(s, ref pos), pos >= s.Length, outputNewLineX2);
                strBuilder.Append(state.Output);
            }

            var result = strBuilder.ToString();
            stringBuilderObjectPool.Return(strBuilder);
            return result;
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
                    ReadOnlySpan<char> result = str.AsSpan(pos, i-pos);
                    pos = i + 1;
                    if (ch == '\r' && pos < length && str[pos] == '\n') pos++;
                    return result;
                }
                i++;
            }
            if (i > pos)
            {
                ReadOnlySpan<char> result = str.AsSpan(pos, i-pos);
                pos = i;
                return result;
            }
            return null;
        }

        static ParserState Parse(in ParserState state, in ReadOnlySpan<char> line, bool lastLine, in ReadOnlySpan<char> outputNewLineX2) => 
            line != null
                ? lastLine
                    ? ParseLine(in state, line, in outputNewLineX2)
                    : ParseLine(in state, line.TrimEnd(), in outputNewLineX2)
                : state.Next(State.EndText);


        static ParserState ParseLine(in ParserState state, in ReadOnlySpan<char> line, in ReadOnlySpan<char> outputNewLine) =>
            IsLineBreak(in line)
                ? state.State switch 
                {
                    State.BeginText => state.Next(State.BeginTextWithLineBreak),
                    State.BeginTextWithLine => state.Next(State.Block, outputNewLine),
                    State.BeginTextWithLineBreak => state.Next(State.BeginTextWithLineBreak),
                    State.Line => state.Next(State.Block, outputNewLine),
                    State.Block => state.Next(State.Block),
                    _ => state.Next(State.EndText)
                } : state.State switch
                {
                    State.BeginText => state.Next(State.BeginTextWithLine, line),
                    State.BeginTextWithLine => Indent(in state, in line, " "),
                    State.BeginTextWithLineBreak => Indent(in state, in line, ReadOnlySpan<char>.Empty),
                    State.Line => state.Next(State.Line, string.Concat(" ", IndentLine(state.Identation, line))),
                    State.Block => state.Next(State.Line, IndentLine(state.Identation, line)),
                    _ => state.Next(State.EndText)
                };

        static ParserState Indent(in ParserState state, in ReadOnlySpan<char> line, in ReadOnlySpan<char> prepend)
        {
            var indent = line.Length - line.TrimStart().Length;
            return state.Next(State.Line, indent, prepend.Length > 0 ? string.Concat(prepend, IndentLine(indent, in line)) : IndentLine(indent, in line));
        }

        static bool EmptyOrWhiteSpace(in ReadOnlySpan<char> text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsWhiteSpace(text[i])) return false;
            }
            return true;
        }

        static bool IsLineBreak(in ReadOnlySpan<char> line) => EmptyOrWhiteSpace(in line);

        static ReadOnlySpan<char> IndentLine(in int identation, in ReadOnlySpan<char> line) => line[Math.Min(identation, line.Length)..];
#endif
    }
}