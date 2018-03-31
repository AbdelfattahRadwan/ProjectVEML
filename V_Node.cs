using System;
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
                string k = key.Trim();
                string v = value.Trim();

                V_DataType vt = (V_DataType)Enum.Parse(typeof(V_DataType), type);

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
            bool c0 = string.Compare(Name, other.Name) == 0;
            bool c1 = Objects.Equals(other.Objects);
            bool c2 = Numbers.Equals(other.Numbers);
            bool c3 = Booleans.Equals(other.Booleans);
            bool c4 = Strings.Equals(other.Strings);

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

        public override string ToString()
        {
            string output = string.Empty;

            output += $"@{Name}";

            if (HasObjects)
            {
                foreach (KeyValuePair<string, object> key in Objects) { output += $"let::{key.Key}::OBJECT::{key.Value}{Environment.NewLine}"; }
            }

            if (HasNumbers)
            {
                foreach (KeyValuePair<string, double> key in Numbers) { output += $"let::{key.Key}::NUMBER::{key.Value}{Environment.NewLine}"; }
            }

            if (HasStrings)
            {
                foreach (KeyValuePair<string, string> key in Strings) { output += $"let::{key.Key}::STRING::{key.Value}{Environment.NewLine}"; }
            }

            if (HasBooleans)
            {
                foreach (KeyValuePair<string, bool> key in Booleans) { output += $"let::{key.Key}::BOOLEAN::{key.Value}{Environment.NewLine}"; }
            }

            return output;
        }
    }
}

