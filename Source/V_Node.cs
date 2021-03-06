﻿using System;
using System.Collections.Generic;

namespace VEML
{
    /// <summary>
    /// Represents a serializable VEML data container.
    /// </summary>
    [Serializable]
    public class V_Node : IEquatable<V_Node>
    {
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, object> Objects { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, double> Numbers { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, string> Strings { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, bool> Booleans { get; set; } = new Dictionary<string, bool>();

        public bool HasObjects => Objects.Count != 0;
        public bool HasNumbers => Numbers.Count != 0;
        public bool HasStrings => Strings.Count != 0;
        public bool HasBooleans => Strings.Count != 0;

        /// <summary>
        /// Adds a key with the specified value to this VemlNode.
        /// </summary>
        /// <param name="type">The type of the value.</param>
        /// <param name="key">The name of the key.</param>
        /// <param name="value">The value of the key.</param>
        public void AddValue(string type, string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                var k = key.Trim();
                var v = value.Trim();

                var vt = (V_DataType)Enum.Parse(typeof(V_DataType), type);

                if (vt.Equals(V_DataType.OBJECT) && !Objects.ContainsKey(k))
                {
                    Objects.Add(k, v);
                }
                else if (vt.Equals(V_DataType.NUMBER) && !Numbers.ContainsKey(k))
                {
                    Numbers.Add(k, float.Parse(v));
                }
                else if (vt.Equals(V_DataType.STRING) && !Strings.ContainsKey(k))
                {
                    Strings.Add(k, v);
                }
                else if (vt.Equals(V_DataType.BOOLEAN) && !Booleans.ContainsKey(k))
                {
                    Booleans.Add(k, bool.Parse(v));
                }
            }
        }

        /// <summary>
        /// Compares this VemlNode to the *other* VemlNode.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(V_Node other)
        {
            var c0 = string.Compare(Name, other.Name) == 0;
            var c1 = Objects.Equals(other.Objects);
            var c2 = Numbers.Equals(other.Numbers);
            var c3 = Booleans.Equals(other.Booleans);
            var c4 = Strings.Equals(other.Strings);

            return c0 && c1 && c2 && c3 && c4;
        }

        /// <summary>
        /// Returns the boolean with the specified key in the node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool GetBoolean(string key)
        {
            if (!Booleans.ContainsKey(key)) { return false; }

            return Booleans[key];
        }

        /// <summary>
        /// Returns the number with the specified key in the node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public double GetNumber(string key)
        {
            if (!Numbers.ContainsKey(key)) { return 0.0; }

            return Numbers[key];
        }

        /// <summary>
        /// Returns the object with the specified key in the node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetObject(string key)
        {
            if (!Objects.ContainsKey(key)) { return null; }

            return Objects[key];
        }

        /// <summary>
        /// Returns the string with the specified key in the node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetString(string key)
        {
            if (!Strings.ContainsKey(key)) { return string.Empty; }

            return Strings[key];
        }

        /// <summary>
        /// Returns a value from the members of the node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            foreach (var num in Numbers)
            {
                if (string.Compare(num.Key, key) == 0)
                {
                    return num.Value;
                }
            }

            foreach (var boolean in Booleans)
            {
                if (string.Compare(boolean.Key, key) == 0)
                {
                    return boolean.Value;
                }
            }

            foreach (var obj in Objects)
            {
                if (string.Compare(obj.Key, key) == 0)
                {
                    return obj.Value;
                }
            }

            foreach (var str in Strings)
            {
                if (string.Compare(str.Key, key) == 0)
                {
                    return str.Value;
                }
            }

            return null;
        }

        public override string ToString()
        {
            var output = string.Empty;

            output += $"@{Name}";

            if (HasObjects)
            {
                foreach (var key in Objects) { output += $"let :: {key.Key} :: OBJECT :: {key.Value}{Environment.NewLine}"; }
            }

            if (HasNumbers)
            {
                foreach (var key in Numbers) { output += $"let :: {key.Key} :: NUMBER :: {key.Value}{Environment.NewLine}"; }
            }

            if (HasStrings)
            {
                foreach (var key in Strings) { output += $"let :: {key.Key} :: STRING :: {key.Value}{Environment.NewLine}"; }
            }

            if (HasBooleans)
            {
                foreach (var key in Booleans) { output += $"let :: {key.Key} :: BOOLEAN :: {key.Value}{Environment.NewLine}"; }
            }

            return output;
        }
    }
}

