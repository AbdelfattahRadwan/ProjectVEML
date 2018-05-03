using System;
using System.Collections.Generic;
using static VEML.V_StringFunctions;

namespace VEML
{
    public static class V_Parser
    {
        /// <summary>
        /// Parses the input snippet and sends the result V_Node to the output V_Node.
        /// </summary>
        /// <param name="snippet"></param>
        /// <param name="output"></param>
        public static void Parse(string snippet, out V_Node output)
        {
            var node = new V_Node();

            var parts = snippet.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
                        node.Name = str.Split(new char[1] { '@' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                    }
                    else if (str.StartsWith("let"))
                    {
                        var memebers = str.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);

                        var type = memebers[2].Trim().ToUpper();

                        node.AddValue(type, memebers[1], memebers[3]);
                    }
                }
            }

            output = node;
        }

        /// <summary>
        /// Parses an array of V_Nodes.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="array"></param>
        public static void ParseArray(string input, out V_Node[] array)
        {
            var list = new List<V_Node>();

            var parts = input.Split(new string[1] { "&>" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                var output = new V_Node();

                Parse(parts[i].Trim(), out output);

                list.Add(output);
            }

            array = list.ToArray();
        }

        /// <summary>
        /// Reads the input string and returns an html tag.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ParseTag(string input)
        {
            var strArray = TrimArray(input.Split(new string[1] { "->" }, StringSplitOptions.RemoveEmptyEntries));

            var id = string.Empty;
            var name = string.Empty;
            var type = string.Empty;
            var onclick = string.Empty;
            var text = string.Empty;
            var value = string.Empty;
            var src = string.Empty;
            var alt_text = string.Empty;
            var width = string.Empty;
            var height = string.Empty;
            var color = string.Empty;
            var size = string.Empty;
            var face = string.Empty;
            var href = string.Empty;

            foreach (var part in strArray)
            {
                var parts = part.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);

                if (part.StartsWith("id")) { id = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("name")) { name = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("type")) { type = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("onclick")) { onclick = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("text")) { text = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("value")) { value = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("src")) { src = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("alt_text")) { alt_text = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("width")) { width = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("height")) { height = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("color")) { color = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("size")) { size = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("face")) { face = (parts.Length >= 2) ? parts[1] : string.Empty; }
                if (part.StartsWith("href")) { href = (parts.Length >= 2) ? parts[1] : string.Empty; }
            }

            if (input.StartsWith("@button")) { return $"<button{ASV(" type", type)}{ASV(" onclick", onclick)}>{text}</button>"; }

            if (input.StartsWith("@paragraph")) { return $"<p>{((strArray.Length >= 2) ? strArray[1] : string.Empty)}</p>"; }

            if (input.StartsWith("@input")) { return $"<input{ASV(" name", name)}{ASV(" type", type)}{ASV(" valie", value)}/>"; }

            if (input.StartsWith("@br")) { return "<br>"; }

            if (input.StartsWith("@title")) { return $"<title>{text}</title>"; }

            if (input.StartsWith("@image"))
            {
                return $"<img{ASV(" src", src)}{ASV(" alt", alt_text)}{ASV(" width", width)}{ASV(" height", height)}/>";
            }

            if (input.StartsWith("@font"))
            {
                return $"<font{ASV(" face", face)}{ASV(" color", color)}{ASV(" size", size)}>";
            }

            if (input.StartsWith("@endFont")) { return "</font>"; }

            if (input.StartsWith("@h1")) { return $"<h1>{text}</h1>"; }

            if (input.StartsWith("@h2")) { return $"<h2>{text}</h2>"; }

            if (input.StartsWith("@h3")) { return $"<h3>{text}</h3>"; }

            if (input.StartsWith("@h4")) { return $"<h4>{text}</h4>"; }

            if (input.StartsWith("@h5")) { return $"<h5>{text}</h5>"; }

            if (input.StartsWith("@h6")) { return $"<h6>{text}</h6>"; }

            if (input.StartsWith("@hyperlink")) { return $"<a{ASV(" href", href)}/>"; }

            if (input.StartsWith("@audioSource")) { return $"<audio controls><source src=\"{ src}\" type=\"{type}\"></audio>"; }

            if (input.StartsWith("@canvas")) { return $"<canvas{ASV(" id", id)}></canvas>"; }

            if (input.StartsWith("@center")) { return "<center>"; }

            if (input.StartsWith("@endCenter")) { return "</center>"; }

            if (input.StartsWith("@table")) { return "<table>"; }

            if (input.StartsWith("@endTable")) { return "</table>"; }

            if (input.StartsWith("@tds"))
            {
                var output = string.Concat(string.Empty, "<tr>", V_Keywords.E_NewLine);

                var data = TrimArray(text.Split(new string[1] { "|+|" }, StringSplitOptions.RemoveEmptyEntries));

                for (int j = 0; j < data.Length; j++)
                {
                    output = string.Concat(output, $"<td>{data[j]}</td>");
                }

                return string.Concat(output, "</tr>");
            }

            if (input.StartsWith("@ths"))
            {
                var output = string.Concat(string.Empty, "<tr>", V_Keywords.E_NewLine);

                var data = TrimArray(text.Split(new string[1] { "|+|" }, StringSplitOptions.RemoveEmptyEntries));

                for (int i = 0; i < data.Length; i++)
                {
                    output = string.Concat(output, $"<th>{data[i]}</th>");
                }

                return string.Concat(output, "</tr>");
            }

            return string.Empty;
        }
    }
}

