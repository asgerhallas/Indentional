using System;
using System.IO;
using System.Text;
using ShinySwitch;

namespace Indentional
{
    public static class Indentional
    {
        public static string Indent(string s) => Indent(Environment.NewLine, s);

        public static string Indent(string outputNewLine, string s)
        {
            var state = new ParserState(State.BeginText, 0, null);
            var input = new StringReader(s);
            var result = new StringBuilder();

            while (state.State != State.EndText)
            {
                state = Parse(state, input.ReadLine(), input.Peek() == -1);
                result.Append(state.Output);
            }

            return result.Replace(Environment.NewLine, outputNewLine).ToString();
        }

        static ParserState Parse(ParserState state, string line, bool lastLine) => 
            line != null 
                ? lastLine
                    ? ParseLine(state, line)
                    : ParseLine(state, line.TrimEnd())
                : state.Next(State.EndText);

        static ParserState ParseLine(ParserState state, string line) =>
            IsLineBreak(line)
                ? Switch<ParserState>.On(state.State)
                    .Match(State.BeginText, _ => state.Next(State.BeginTextWithLineBreak))
                    .Match(State.BeginTextWithLine, _ => state.Next(State.Block, $"{Environment.NewLine}{Environment.NewLine}"))
                    .Match(State.BeginTextWithLineBreak, _ => state.Next(State.BeginTextWithLineBreak))
                    .Match(State.Line, _ => state.Next(State.Block, $"{Environment.NewLine}{Environment.NewLine}"))
                    .Match(State.Block, _ => state.Next(State.Block))
                    .Else(() => state.Next(State.EndText))
                : Switch<ParserState>.On(state.State)
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
}