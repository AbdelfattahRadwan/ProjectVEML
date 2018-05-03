using System;
using System.Text;
using static VEML.V_Parser;
using static VEML.V_StringFunctions;

namespace VEML
{
    public static class V_Convert
    {
        public static string ToHTML(string veml)
        {
            var builder = new StringBuilder();

            var parts = TrimArray(veml.Split(new char[1] { '~' }, StringSplitOptions.RemoveEmptyEntries));

            var newline = new string[1] { Environment.NewLine };

            builder.AppendLine("<html>");            

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("@head"))
                {
                    builder.AppendLine("<head>");

                    var strings = parts[i].Split(newline, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++) { builder.AppendLine(ParseTag(strings[j])); }

                    builder.AppendLine("</head>");
                }
                else if (parts[i].StartsWith("@body"))
                {
                    builder.AppendLine("<body>");

                    var strings = parts[i].Split(newline, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++) { builder.AppendLine(ParseTag(strings[j])); }

                    builder.AppendLine("</body>");
                }
                else if (parts[i].StartsWith("@script"))
                {
                    builder.AppendLine("<script>");

                    var strings = parts[i].Split(newline, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++) { builder.Append(strings[j] + Environment.NewLine); }

                    builder.AppendLine("</script>");
                }
                else if (parts[i].StartsWith("@style"))
                {
                    builder.AppendLine("<style>");

                    var strArray5 = parts[i].Split(newline, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strArray5.Length; j++) { builder.Append(strArray5[j] + Environment.NewLine); }

                    builder.AppendLine("</style>");
                }
                else if (parts[i].StartsWith("@form"))
                {
                    builder.AppendLine("<form>");

                    var strings = parts[i].Split(newline, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++) { builder.AppendLine(ParseTag(strings[j])); }

                    builder.AppendLine("</form>");
                }
            }

            builder.AppendLine("</html>");

            return builder.ToString();
        }
    }
}

