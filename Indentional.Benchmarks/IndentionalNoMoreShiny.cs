using System;
using System.IO;
using System.Text;

namespace Indentional
{
    public static class IndentionalNoMoreShiny
    {
        public static string _(string s) => Indent(s);

        public static string _(string outputNewLine, string s) => Indent(outputNewLine, s);
        
        public static string Indent(string s) => _(Environment.NewLine, s);

        public static string Indent(string outputNewLine, string s)
        {
            var state = new OriginalParserState(State.BeginText, 0, null);
            var input = new StringReader(s);
            var result = new StringBuilder();
            
            while (state.State != State.EndText)
            {
                state = Parse(state, input.ReadLine(), input.Peek() == -1);
                result.Append(state.Output);
            }

            return result.Replace(Environment.NewLine, outputNewLine).ToString();
        }

        static OriginalParserState Parse(OriginalParserState state, string line, bool lastLine) => 
            line != null 
                ? lastLine
                    ? ParseLine(state, line)
                    : ParseLine(state, line.TrimEnd())
                : state.Next(State.EndText);

        static OriginalParserState ParseLine(OriginalParserState state, string line) =>
            IsLineBreak(line)
                ? state.State switch
                {
                    State.BeginText => state.Next(State.BeginTextWithLineBreak),
                    State.BeginTextWithLine => state.Next(State.Block, $"{Environment.NewLine}{Environment.NewLine}"),
                    State.BeginTextWithLineBreak => state.Next(State.BeginTextWithLineBreak),
                    State.Line => state.Next(State.Block, $"{Environment.NewLine}{Environment.NewLine}"),
                    State.Block => state.Next(State.Block),
                    _ => state.Next(State.EndText)
                }
                : state.State switch
                {
                    State.BeginText => state.Next(State.BeginTextWithLine, line),
                    State.BeginTextWithLine => Indent(state, line, " "),
                    State.BeginTextWithLineBreak => Indent(state, line, ""),
                    State.Line => state.Next(State.Line, $" {IndentLine(state.Identation, line)}"),
                    State.Block => state.Next(State.Line, $"{IndentLine(state.Identation, line)}"),
                    _ => state.Next(State.EndText)
                };

        static OriginalParserState Indent(OriginalParserState state, string line, string prepend)
        {
            var indent = line.Length - line.TrimStart().Length;
            return state.Next(State.Line, indent, prepend + IndentLine(indent, line));
        }

        static bool IsLineBreak(string line) => line.Trim().Length == 0;

        static string IndentLine(int identation, string line) => line.Remove(0, Math.Min(identation, line.Length));
    }
}