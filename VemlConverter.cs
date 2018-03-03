using System;
using System.Text;
using static VEML.Text.StringFunctions;

namespace VEML
{
    public static class VemlConverter
    {
        public static string ToHTML(string veml)
        {
            StringBuilder builder = new StringBuilder();

            string[] parts = TrimArray(veml.Split(new char[1] { '~' }, StringSplitOptions.RemoveEmptyEntries));

            builder.AppendLine("<html>");

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("@head"))
                {
                    builder.AppendLine("<head>");
                    string[] strings = parts[i].Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++)
                    {
                        builder.AppendLine(ParseTag(strings[j]));
                    }

                    builder.AppendLine("</head>");
                }

                if (parts[i].StartsWith("@body"))
                {
                    builder.AppendLine("<body>");
                    string[] strings = parts[i].Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++)
                    {
                        builder.AppendLine(ParseTag(strings[j]));
                    }

                    builder.AppendLine("</body>");
                }

                if (parts[i].StartsWith("@script"))
                {
                    builder.AppendLine("<script>");
                    string[] strings = parts[i].Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++)
                    {
                        builder.Append(strings[j] + "\r\n");
                    }

                    builder.AppendLine("</script>");
                }

                if (parts[i].StartsWith("@style"))
                {
                    builder.AppendLine("<style>");
                    string[] strArray5 = parts[i].Split(new char[1] { '\n' });

                    for (int j = 1; j < strArray5.Length; j++)
                    {
                        builder.Append(strArray5[j] + "\r\n");
                    }

                    builder.AppendLine("</style>");
                }

                if (parts[i].StartsWith("@form"))
                {
                    builder.AppendLine("<form>");
                    string[] strings = parts[i].Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 1; j < strings.Length; j++)
                    {
                        builder.AppendLine(ParseTag(strings[j]));
                    }

                    builder.AppendLine("</form>");
                }
            }

            builder.AppendLine("</html>");

            return builder.ToString();
        }
    }
}

