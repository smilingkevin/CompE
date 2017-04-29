namespace CompE.Domain
{
    public static class Extensions
    {
        public static string Int(this bool value)
        {
            return value ? "1" : "0";
        }
    }
}
