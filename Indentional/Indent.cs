using System;
using System.IO;
using System.Text;

namespace Indentional
{
    public static class Indent
    {
        public static string _(string s)
        {
            if (s == null) return null;

            var builder = new StringBuilder();
            var reader = new StringReader(s);
            var line = reader.ReadLine();

            if (line == null) return s;

            if (line.Trim().Length > 0)
            {
                builder.AppendLine(line);
            }

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim().Length == 0)
                {
                    builder.AppendLine();
                }
                else
                {
                    break;
                }
            }

            if (line == null)
            {
                return builder.ToString();
            }

            var trimmed = line.TrimStart();
            var indent = line.Length - trimmed.Length;

            builder.Append(trimmed);

            while ((line = reader.ReadLine()) != null)
            {
                builder.AppendLine();
                builder.Append(line.Remove(0, Math.Min(indent, line.Length)));
            } 

            return builder.ToString();
        }
    }
}
