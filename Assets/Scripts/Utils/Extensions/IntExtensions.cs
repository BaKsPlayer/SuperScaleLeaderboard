namespace SC.Utils
{
    public static class IntExtensions
    {
        public static string ToString(this int number, bool withWhiteSpace)
        {
            return withWhiteSpace ? string.Format("{0:n0}", number).Replace(',', ' ') : number.ToString();
        }
    }
}