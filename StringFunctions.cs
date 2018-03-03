using System;

namespace VEML.Text
{
    public static class StringFunctions
    {
        public static string FullTrim(this string str)
        {
            while (str.IndexOf(" ") > -1)
            {
                str = str.Replace(" ", string.Empty);
            }

            return str;
        }

        public static int InsertAndGetIndex(ref string target, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            target = target + input;

            return (target.IndexOf(input) + input.Length);
        }

        public static string ParseTag(string input)
        {
            string[] strArray = TrimArray(input.Split(new string[1] { "->" }, StringSplitOptions.RemoveEmptyEntries));

            string id = string.Empty;
            string name = string.Empty;
            string type = string.Empty;
            string onclick = string.Empty;
            string text = string.Empty;
            string value = string.Empty;
            string src = string.Empty;
            string alt_text = string.Empty;
            string width = string.Empty;
            string height = string.Empty;
            string color = string.Empty;
            string size = string.Empty;
            string face = string.Empty;
            string href = string.Empty;

            foreach (string part in strArray)
            {
                string[] parts = part.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);

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
                string output = string.Concat(string.Empty, "<tr>\r\n");

                string[] data = TrimArray(text.Split(new string[1] { "|&|" }, StringSplitOptions.RemoveEmptyEntries));

                for (int j = 0; j < data.Length; j++)
                {
                    output = string.Concat(output, $"<td>{data[j]}</td>");
                }

                return string.Concat(output, "</tr>");
            }

            if (input.StartsWith("@ths"))
            {
                string output = string.Concat(string.Empty, "<tr>\r\n");

                string[] data = TrimArray(text.Split(new string[1] { "|&|" }, StringSplitOptions.RemoveEmptyEntries));

                for (int i = 0; i < data.Length; i++)
                {
                    output = string.Concat(output, $"<th>{data[i]}</th>");
                }

                return string.Concat(output, "</tr>");
            }

            return string.Empty;
        }

        public static string ASV(string text, string value)
        {
            if ((!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text)) && (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)))
            {
                return $"{text}=\"{value}\"";
            }

            return string.Empty;
        }

        public static string TagStrVal(string text, string value)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
            {
                return $"{text}=\"{ value}\"";
            }

            return string.Empty;
        }

        public static string[] TrimArray(string[] array)
        {
            if (array.Length == 0)
            {
                return new string[0];
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Trim();
            }
            return array;
        }
    }
}

