namespace Memphis.Extensions
{
    public static partial class Extension
    {
        public static string Up(this string loc)
        {
            return loc.Split('\\').RemoveLast().Join(@"\");
        }
    }
}
