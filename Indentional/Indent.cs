using System;
using System.IO;
using System.Text;
using ShinySwitch;

namespace Indentional
{
    public static class Indent
    {
        public static string _(string s)
        {
            var state = new ParserState(State.BeginText, 0, null);
            var input = new StringReader(s);
            var result = new StringBuilder();

            while (state.State != State.EndText)
            {
                state = Parse(state, input.ReadLine());
                result.Append(state.Output);
            }

            return result.ToString();
        }

        static ParserState Parse(ParserState state, string line)
        {
            return line != null ? ParseLine(state, line) : state.Next(State.EndText);
        }
        
        static ParserState ParseLine(ParserState state, string line)
        {
            return IsLineBreak(line)
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
        }

        static bool IsLineBreak(string line)
        {
            return line.Trim().Length == 0;
        }

        static string IndentLine(int identation, string line)
        {
            return line.Remove(0, Math.Min(identation, line.Length));
        }
    }

    public class ParserState
    {
        public ParserState(State state, int identation, string output)
        {
            State = state;
            Identation = identation;
            Output = output;
        }

        public State State { get; }
        public int Identation { get; }
        public string Output { get; }

        public ParserState Next(State state)
        {
            return new ParserState(state, Identation, null);
        }

        public ParserState Next(State state, string value)
        {
            return new ParserState(state, Identation, value);
        }

        public ParserState Next(State state, int indentation, string value)
        {
            return new ParserState(state, indentation, value);
        }
    }

    public enum State
    {
        BeginText,
        BeginTextWithLine,
        BeginTextWithLineBreak,
        Line,
        Block,
        EndText
    }
}