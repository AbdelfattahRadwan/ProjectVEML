namespace VEML
{
    public static class V_StringFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ASV(string text, string value)
        {
            if ((!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text)) && (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)))
            {
                return $"{text}=\"{value}\"";
            }

            return string.Empty;
        }

        /// <summary>
        /// Trims an array of strings.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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

