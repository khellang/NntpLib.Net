using System.Linq;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class PostExtensionsTests
    {
        [Trait("Category", "RFC 3977 - NNTP")]
        public class Post : CommandTest
        {
            [Fact]
            public void ShouldThrowPullRequestExceptionUtilSomeoneImplementsIt()
            {
                Assert.Throws<PullRequestException>(() => Connection.Post(Enumerable.Empty<string>()));
            }    
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class IHave : CommandTest
        {
            [Fact]
            public void ShouldThrowPullRequestExceptionUtilSomeoneImplementsIt()
            {
                Assert.Throws<PullRequestException>(() => Connection.IHave(string.Empty, Enumerable.Empty<string>()));
            }    
        }
    }
}