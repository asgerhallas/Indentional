namespace Indentional
{
    public enum State : byte
    {
        BeginText,
        BeginTextWithLine,
        BeginTextWithLineBreak,
        Line,
        Block,
        EndText
    }
}