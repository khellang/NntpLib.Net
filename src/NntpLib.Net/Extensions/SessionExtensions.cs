namespace NntpLib.Net
{
    public static class SessionExtensions
    {
        public static NntpMultilineResponse Capabilities(this INntpConnection connection, string keyword = null)
        {
            var command = CommandBuilder.Build("CAPABILITIES", builder =>
            {
                if (!string.IsNullOrWhiteSpace(keyword)) builder.AddParameter(keyword);
            });

            return connection.ExecuteMultilineCommand(command, 101);
        }

        public static NntpResponse ModeReader(this INntpConnection connection)
        {
            return connection.ExecuteCommand("MODE READER");
        }

        public static NntpResponse Quit(this INntpConnection connection)
        {
            return connection.ExecuteCommand("QUIT");
        }
    }
}