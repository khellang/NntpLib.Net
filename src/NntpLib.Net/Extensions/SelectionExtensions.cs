namespace NntpLib.Net
{
    public static class SelectionExtensions
    {
        public static NntpResponse Group(this INntpConnection connection, string group)
        {
            var command = string.Format("GROUP {0}", group);

            return connection.ExecuteCommand(command);
        }

        public static NntpMultilineResponse ListGroup(this INntpConnection connection, string group, int articleNo)
        {
            var command = string.Format("LISTGROUP {0} {1}", group, articleNo);

            return connection.ExecuteMultilineCommand(command, 211);
        }

        public static NntpMultilineResponse ListGroup(this INntpConnection connection, string group = null, Range range = null)
        {
            var command = CommandBuilder.Build("LISTGROUP", builder =>
            {
                if (string.IsNullOrWhiteSpace(group)) return;

                builder.AddParameter(group);
                if (range != null)
                {
                    builder.AddParameter(range);
                }
            });

            return connection.ExecuteMultilineCommand(command, 211);
        }

        public static NntpResponse Last(this INntpConnection connection)
        {
            return connection.ExecuteCommand("LAST");
        }

        public static NntpResponse Next(this INntpConnection connection)
        {
            return connection.ExecuteCommand("NEXT");
        }
    }
}