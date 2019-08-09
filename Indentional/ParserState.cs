namespace Indentional
{
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

        public ParserState Next(State state) => new ParserState(state, Identation, null);

        public ParserState Next(State state, string value) => new ParserState(state, Identation, value);

        public ParserState Next(State state, int indentation, string value) => new ParserState(state, indentation, value);
    }
}