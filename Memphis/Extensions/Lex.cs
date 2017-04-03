using System.Collections.Generic;

namespace Memphis.Extensions
{
    public static partial class Extension
    {
        public static string[] Lex(this string s)
        {
            bool isinquotes = false;
            List<string> tokens = new List<string> { "" };
            foreach (char c in s)
            {
                if (c == '"') { isinquotes = !isinquotes; }
                else if (char.IsWhiteSpace(c) && isinquotes == false) { tokens.Add(""); }
                else { tokens[tokens.Count - 1] += c; }
            }
            return tokens.ToArray();
        }
    }
}
