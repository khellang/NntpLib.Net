namespace NntpLib.Net
{
    public static class AuthExtensions
    {
        public static NntpResponse AuthInfoUser(this INntpConnection connection, string username)
        {
            var command = string.Format("AUTHINFO USER {0}", username);

            return connection.ExecuteCommand(command);
        }

        public static NntpResponse AuthInfoPass(this INntpConnection connection, string password)
        {
            var command = string.Format("AUTHINFO PASS {0}", password);

            return connection.ExecuteCommand(command);
        }

        public static NntpResponse AuthInfoSasl(this INntpConnection conneciton, string mechanism, string intitialResponse)
        {
            throw new PullRequestException();
        }
    }
}
