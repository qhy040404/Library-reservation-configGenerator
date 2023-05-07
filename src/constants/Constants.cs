namespace ConfigGenerator.src.constants
{
    public class Constants
    {
        private Constants()
        {
            throw new NotSupportedException();
        }

        private static readonly string[] LXArray = new string[]
        {
            "201", "202", "301", "302", "401", "402", "501", "502", "601", "602"
        };

        private static readonly string[] BCArray = new string[]
        {
            "301", "312", "401", "404", "409", "501", "504", "507"
        };

        public static readonly string LX = "令希";
        public static readonly string BC = "伯川";

        public static readonly Dictionary<string, string> areas = new()
        {
            {LX, "LX"},
            {BC, "BC"}
        };

        public static readonly Dictionary<string, string[]> libraries = new()
        {
            {LX, LXArray},
            {BC, BCArray}
        };
    }
}
