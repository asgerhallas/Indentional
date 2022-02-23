using System;

namespace Indentional
{
    public static class IndentionalEx
    {
        public static string Indent(this string s) => Parser.Indent(Environment.NewLine, s);
        public static string Indent(this string s, string outputNewLine) => Parser.Indent(outputNewLine, s);
    }
}