namespace Memphis
{
    public static class Extensions
    {
        public static string Join(this string[] args, string join)
        {
            string j = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0)
                {
                    j = args[0];
                }
                else
                {
                    j += join + args[i];
                }
            }
            return j;
        }
    }
}
