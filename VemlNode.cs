namespace VEML
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class VemlNode
    {
        public string name;
        public Dictionary<string, object> objects;
        public Dictionary<string, double> numbers;
        public Dictionary<string, string> strings;
        public Dictionary<string, bool> booleans;

        public VemlNode()
        {
            objects = new Dictionary<string, object>();
            numbers = new Dictionary<string, double>();
            strings = new Dictionary<string, string>();
            booleans = new Dictionary<string, bool>();
        }

        public VemlNode(string name, Dictionary<string, object> objects, Dictionary<string, double> numbers, Dictionary<string, string> strings, Dictionary<string, bool> booleans)
        {
            this.objects = new Dictionary<string, object>();
            this.numbers = new Dictionary<string, double>();
            this.strings = new Dictionary<string, string>();
            this.booleans = new Dictionary<string, bool>();
            this.name = name;
            this.objects = objects;
            this.numbers = numbers;
            this.strings = strings;
            this.booleans = booleans;
        }

        public void AddValue(string type, string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                string t = key.Trim();
                string v = value.Trim();

                VEMLDataType valueType = (VEMLDataType)Enum.Parse(typeof(VEMLDataType), type);

                if (valueType.Equals(VEMLDataType.OBJECT) && !objects.ContainsKey(t))
                {
                    objects.Add(t, v);
                }
                else if (valueType.Equals(VEMLDataType.NUMBER) && !numbers.ContainsKey(t))
                {
                    numbers.Add(t, float.Parse(v));
                }
                else if (valueType.Equals(VEMLDataType.STRING) && !strings.ContainsKey(t))
                {
                    strings.Add(t, v);
                }
                else if (valueType.Equals(VEMLDataType.BOOLEAN) && !booleans.ContainsKey(t))
                {
                    booleans.Add(t, bool.Parse(v));
                }
            }
        }

        public bool GetBoolean(string key)
        {
            if (!booleans.ContainsKey(key))
            {
                return false;
            }

            return booleans[key];
        }

        public double GetNumber(string key)
        {
            if (!numbers.ContainsKey(key))
            {
                return 0.0;
            }

            return numbers[key];
        }

        public object GetObject(string key)
        {
            if (!objects.ContainsKey(key))
            {
                return null;
            }

            return objects[key];
        }

        public string GetString(string key)
        {
            if (!this.strings.ContainsKey(key))
            {
                return string.Empty;
            }

            return strings[key];
        }

        public override string ToString()
        {
            string output = string.Empty;

            output = string.Concat(output, $"{{NAME}} {name}");

            if (objects.Count != 0)
            {
                foreach (KeyValuePair<string, object> pair in objects)
                {
                    output = string.Concat(output, $"{{OBJECT}} {pair.Key}: {pair.Value.ToString()}");
                }
            }

            if (numbers.Count != 0)
            {
                foreach (KeyValuePair<string, double> pair2 in numbers)
                {
                    output = string.Concat(output, $"{{NUMBER}} {pair2.Key}: {pair2.Value}");
                }
            }

            if (strings.Count != 0)
            {
                foreach (KeyValuePair<string, string> pair3 in strings)
                {
                    output = string.Concat(output, $"{{STRING}} {pair3.Key}: {pair3.Value}");
                }
            }

            if (booleans.Count != 0)
            {
                foreach (KeyValuePair<string, bool> pair4 in booleans)
                {
                    output = string.Concat(output, $"{{BOOLEAN}} {pair4.Key}: {pair4.Value}");
                }
            }
            return output;
        }
    }
}

