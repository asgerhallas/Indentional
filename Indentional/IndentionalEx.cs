using System;

namespace Indentional
{
    public static class IndentionalEx
    {
        public static string Indent(this string s) => Text.Indent(Environment.NewLine, s);
        public static string Indent(this string s, string outputNewLine) => Text.Indent(outputNewLine, s);
    }
}