namespace NntpLib.Net.Console
{
    public static class Program
    {
        public static void Main()
        {
            var connection = new NntpConnection();

            var resp = connection.Connect("USENET HOST", 563, true);

            var resp1 = connection.AuthInfoUser("USERNAME");

            var resp2 = connection.AuthInfoPass("PASSWORD");

            var resp3 = connection.Group("NEWSGROUP");

            var overResponse = connection.Over(Range.From(1).To(10));
        }
    }
}
