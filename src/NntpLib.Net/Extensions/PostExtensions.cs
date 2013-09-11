using System.Collections.Generic;

namespace NntpLib.Net
{
    public static class PostExtensions
    {
        public static NntpResponse Post(this INntpConnection connection, IEnumerable<string> article)
        {
            throw new PullRequestException();
        }

        public static NntpResponse IHave(this INntpConnection connection, string messageId, IEnumerable<string> article)
        {
            throw new PullRequestException();  
        }
    }
}