using System;

namespace NntpLib.Net
{
    public static class RetrievalExtensions
    {
        public static NntpMultilineResponse Article(this INntpConnection connection, string messageId)
        {
            return ExecuteArticleCommand(connection, "ARTICLE", messageId, 220);
        }

        public static NntpMultilineResponse Article(this INntpConnection connection, int? articleNo = null)
        {
            return ExecuteArticleCommand(connection, "ARTICLE", articleNo, 220);
        }

        public static NntpMultilineResponse Head(this INntpConnection connection, string messageId)
        {
            return ExecuteArticleCommand(connection, "HEAD", messageId, 221);
        }

        public static NntpMultilineResponse Head(this INntpConnection connection, int? articleNo = null)
        {
            return ExecuteArticleCommand(connection, "HEAD", articleNo, 221);
        }

        public static NntpMultilineResponse Body(this INntpConnection connection, string messageId)
        {
            return ExecuteArticleCommand(connection, "BODY", messageId, 222);
        }

        public static NntpMultilineResponse Body(this INntpConnection connection, int? articleNo = null)
        {
            return ExecuteArticleCommand(connection, "BODY", articleNo, 222);
        }

        public static NntpResponse Stat(this INntpConnection connection, string messageId)
        {
            return ExecuteArticleCommand(connection, "STAT", messageId, 223);
        }

        public static NntpResponse Stat(this INntpConnection connection, int? articleNo = null)
        {
            return ExecuteArticleCommand(connection, "STAT", articleNo, 223);
        }

        private static NntpMultilineResponse ExecuteArticleCommand(INntpConnection connection, string command, string messageId, int validCode)
        {
            return connection.ExecuteMultilineCommand(string.Join(" ", command, messageId.WithBrackets()), validCode);
        }

        private static NntpMultilineResponse ExecuteArticleCommand(INntpConnection connection, string command, int? articleNo, int validCode)
        {
            var articleCommand = CommandBuilder.Build(command, builder =>
            {
                if (articleNo.HasValue) builder.AddParameter(articleNo.Value);
            });

            return connection.ExecuteMultilineCommand(articleCommand, validCode);
        }
    }
}