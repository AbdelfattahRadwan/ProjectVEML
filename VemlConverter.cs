﻿using System;
using System.Reflection;
using System.Text;
using static VEML.V_StringFunctions;
using static VEML.V_Parser;

namespace VEML
{
    public static class V_Convert
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
                    string[] strings = parts[i].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j < strings.Length; j++) { builder.AppendLine(ParseTag(strings[j])); }
                    builder.AppendLine("</head>");
                }

                if (parts[i].StartsWith("@body"))
                {
                    builder.AppendLine("<body>");
                    string[] strings = parts[i].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j < strings.Length; j++) { builder.AppendLine(ParseTag(strings[j])); }
                    builder.AppendLine("</body>");
                }

                if (parts[i].StartsWith("@script"))
                {
                    builder.AppendLine("<script>");
                    string[] strings = parts[i].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j < strings.Length; j++) { builder.Append(strings[j] + Environment.NewLine); }
                    builder.AppendLine("</script>");
                }

                if (parts[i].StartsWith("@style"))
                {
                    builder.AppendLine("<style>");
                    string[] strArray5 = parts[i].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j < strArray5.Length; j++) { builder.Append(strArray5[j] + Environment.NewLine); }
                    builder.AppendLine("</style>");
                }

                if (parts[i].StartsWith("@form"))
                {
                    builder.AppendLine("<form>");
                    string[] strings = parts[i].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j < strings.Length; j++) { builder.AppendLine(ParseTag(strings[j])); }
                    builder.AppendLine("</form>");
                }
            }

            builder.AppendLine("</html>");

            return builder.ToString();
        }

        public static string Serialize(object obj)
        {
            V_Node vemlNode = new V_Node
            {
                Name = obj.GetType().Name
            };

            FieldInfo[] fields = obj.GetType().GetFields();
            PropertyInfo[] properties = obj.GetType().GetProperties();

            if (fields.Length != 0)
            {
                foreach (FieldInfo field in fields)
                {
                    vemlNode.AddValue("OBJECT", field.Name, field.GetValue(obj.GetType()).ToString());
                }
            }

            if (properties.Length != 0)
            {
                foreach (PropertyInfo property in properties)
                {
                    vemlNode.AddValue("OBJECT", property.Name, property.GetValue(obj.GetType()).ToString());
                }
            }

            return vemlNode.ToString();
        }
    }
}

