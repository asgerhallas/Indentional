namespace Indentional.Standard2
{
    internal class OriginalParserState
    {
        public OriginalParserState(State state, int identation, string output)
        {
            State = state;
            Identation = identation;
            Output = output;
        }

        public State State { get; }
        public int Identation { get; }
        public string Output { get; }

        public OriginalParserState Next(State state) => new OriginalParserState(state, Identation, null);

        public OriginalParserState Next(State state, string value) => new OriginalParserState(state, Identation, value);

        public OriginalParserState Next(State state, int indentation, string value) => new OriginalParserState(state, indentation, value);
    }
}