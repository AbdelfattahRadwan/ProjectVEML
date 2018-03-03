using System;
using System.Collections.Generic;

namespace VEML
{
    public static class VemlParser
    {
        public static void Parse(string snippet, out VemlNode output)
        {
            VemlNode node = new VemlNode();

            string[] parts = snippet.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim();
            }

            foreach (string str in parts)
            {
                if ((!str.StartsWith("!") && !string.IsNullOrWhiteSpace(str)) && !string.IsNullOrEmpty(str))
                {
                    if (str.StartsWith("@"))
                    {
                        node.name = str.Split(new char[1] { '@' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                    }
                    else if (str.StartsWith("let"))
                    {
                        string[] memebers = str.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                        string type = memebers[2].Trim().ToUpper();

                        node.AddValue(type, memebers[1], memebers[3]);
                    }
                }
            }

            output = node;
        }

        public static void ParseArray(string input, out VemlNode[] array)
        {
            List<VemlNode> list = new List<VemlNode>();

            string[] parts = input.Split(new string[1] { "&>" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                VemlNode output = new VemlNode();
                Parse(parts[i].Trim(), out output);
                list.Add(output);
            }

            array = list.ToArray();
        }
    }
}

