﻿
namespace Indentional.Standard2 {
#if NETSTANDARD2_0
    using ShinySwitch;
    using System;
    using System.IO;
    using System.Text;

    internal class IndentionalOriginal
    {
        public static string _(string s) => Indent(s);

        public static string _(string outputNewLine, string s) => Indent(outputNewLine, s);

        public static string Indent(string s) => _(Environment.NewLine, s);

        public static string Indent(string outputNewLine, string s)
        {
            var state = new OriginalParserState(State.BeginText, 0, null);
            var input = new StringReader(s);
            var result = new StringBuilder();

            var outputNewLineX2 = outputNewLine + outputNewLine;

            while (state.State != State.EndText)
            {
                state = Parse(state, input.ReadLine(), input.Peek() == -1, outputNewLineX2);
                result.Append(state.Output);
            }

            return result.ToString();
        }

        static OriginalParserState Parse(OriginalParserState state, string line, bool lastLine, string outputNewLine) =>
            line != null
                ? lastLine
                    ? ParseLine(state, line, outputNewLine)
                    : ParseLine(state, line.TrimEnd(), outputNewLine)
                : state.Next(State.EndText);

        static OriginalParserState ParseLine(OriginalParserState state, string line, string outputNewLine) =>
            IsLineBreak(line)
                ? Switch<OriginalParserState>.On(state.State)
                    .Match(State.BeginText, _ => state.Next(State.BeginTextWithLineBreak))
                    .Match(State.BeginTextWithLine, _ => state.Next(State.Block, outputNewLine))
                    .Match(State.BeginTextWithLineBreak, _ => state.Next(State.BeginTextWithLineBreak))
                    .Match(State.Line, _ => state.Next(State.Block, outputNewLine))
                    .Match(State.Block, _ => state.Next(State.Block))
                    .Else(() => state.Next(State.EndText))
                : Switch<OriginalParserState>.On(state.State)
                    .Match(State.BeginText, _ => state.Next(State.BeginTextWithLine, line))
                    .Match(State.BeginTextWithLine, _ =>
                    {
                        var indent = line.Length - line.TrimStart().Length;
                        return state.Next(State.Line, indent, $" {IndentLine(indent, line)}");
                    })
                    .Match(State.BeginTextWithLineBreak, _ =>
                    {
                        var indent = line.Length - line.TrimStart().Length;
                        return state.Next(State.Line, indent, $"{IndentLine(indent, line)}");
                    })
                    .Match(State.Line, _ => state.Next(State.Line, $" {IndentLine(state.Identation, line)}"))
                    .Match(State.Block, _ => state.Next(State.Line, $"{IndentLine(state.Identation, line)}"))
                    .Else(() => state.Next(State.EndText));

        static bool IsLineBreak(string line) => line.Trim().Length == 0;

        static string IndentLine(int identation, string line) => line.Remove(0, Math.Min(identation, line.Length));
    }
#endif
}
