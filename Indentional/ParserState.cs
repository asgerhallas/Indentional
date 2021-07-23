using System;

namespace Indentional
{
    public readonly ref struct ParserState
    {
        public ParserState(State state, int identation, in ReadOnlySpan<char> output)
        {
            State = state;
            Identation = identation;
            Output = output;
        }

        public State State { get; }
        public int Identation { get; }
        public ReadOnlySpan<char> Output { get; }

        public ParserState Next(in State state) => new ParserState(state, Identation, ReadOnlySpan<char>.Empty);

        public ParserState Next(in State state, in ReadOnlySpan<char> value) => new ParserState(state, Identation, in value);

        public ParserState Next(in State state, int indentation, in ReadOnlySpan<char> value) => new ParserState(state, indentation, in value);
    }
}