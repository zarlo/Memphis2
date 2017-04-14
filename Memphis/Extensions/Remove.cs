namespace Memphis.Extensions
{
    public static partial class Extension
    {
        public static T[] RemoveFirst<T>(this T[] s)
        {
            T[] ret = new T[s.Length > 1 ? s.Length - 1 : 0];
            for (int i = 1; i < s.Length; i++)
                ret[i - 1] = s[i];
            return ret;
        }
        public static T[] RemoveLast<T>(this T[] s)
        {
            T[] ret = new T[s.Length > 1 ? s.Length - 1 : 0];
            for (int i = 0; i < s.Length - 1; i++)
                ret[i] = s[i];
            return ret;
        }
    }
}
