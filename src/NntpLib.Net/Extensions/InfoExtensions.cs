using System;

namespace NntpLib.Net
{
    public static class InfoExtensions
    {
        public static NntpResponse Date(this INntpConnection connection)
        {
            return connection.ExecuteCommand("DATE");
        }

        public static NntpMultilineResponse Help(this INntpConnection connection)
        {
            return connection.ExecuteMultilineCommand("HELP", 100);
        }

        public static NntpMultilineResponse NewGroups(this INntpConnection connection, DateTime createdSince, bool isGmt = false)
        {
            var command = CommandBuilder.Build("NEWGROUPS", builder =>
            {
                builder.AddDateAndTimeParameters(createdSince);
                if (isGmt)
                {
                    builder.AddParameter("GMT");
                }
            });

            return connection.ExecuteMultilineCommand(command, 231);
        }

        public static NntpMultilineResponse NewNews(this INntpConnection connection, DateTime createdSince, string wildmat, bool isGmt = false)
        {
            var command = CommandBuilder.Build("NEWNEWS", builder =>
            {
                builder.AddParameter(wildmat);
                builder.AddDateAndTimeParameters(createdSince);
                if (isGmt)
                {
                    builder.AddParameter("GMT");
                }
            });

            return connection.ExecuteMultilineCommand(command, 230);
        }

        public static NntpMultilineResponse List(this INntpConnection connection, ListKeyword? keyword = null, string wildmatOrArgument = null)
        {
            var command = CommandBuilder.Build("LIST", builder =>
            {
                if (!keyword.HasValue) return;

                builder.AddParameter(keyword.Value.GetDescription());

                if (!string.IsNullOrWhiteSpace(wildmatOrArgument))
                {
                    builder.AddParameter(wildmatOrArgument);
                }
            });

            return connection.ExecuteMultilineCommand(command, 215);
        }

        public static NntpMultilineResponse Over(this INntpConnection connection, string messageId)
        {
            var command = string.Format("OVER {0}", messageId.WithBrackets());

            return connection.ExecuteMultilineCommand(command, 224);
        }

        public static NntpMultilineResponse Over(this INntpConnection connection, int? articleNo = null)
        {
            var command = CommandBuilder.Build("OVER", builder =>
            {
                if (articleNo.HasValue) builder.AddParameter(articleNo.Value);
            });

            return connection.ExecuteMultilineCommand(command, 224);
        }

        public static NntpMultilineResponse Over(this INntpConnection connection, Range range)
        {
            var command = string.Format("OVER {0}", range);

            return connection.ExecuteMultilineCommand(command, 224);
        }

        public static NntpMultilineResponse Hdr(this INntpConnection connection, string field, string messageId)
        {
            var command = string.Format("HDR {0} {1}", field, messageId.WithBrackets());

            return connection.ExecuteMultilineCommand(command, 225);
        }

        public static NntpMultilineResponse Hdr(this INntpConnection connection, string field, int? articleNo = null)
        {
            var command = CommandBuilder.Build(string.Format("HDR {0}", field), builder =>
            {
                if (articleNo.HasValue) builder.AddParameter(articleNo.Value);
            });

            return connection.ExecuteMultilineCommand(command, 225);
        }

        public static NntpMultilineResponse Hdr(this INntpConnection connection, string field, Range range)
        {
            var command = string.Format("HDR {0} {1}", field, range);

            return connection.ExecuteMultilineCommand(command, 225);
        }
    }
}