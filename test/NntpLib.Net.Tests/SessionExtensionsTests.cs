using Xunit;

namespace NntpLib.Net.Tests
{
    public class SessionExtensionsTests
    {
        [Trait("Category", "RFC 3977 - NNTP")]
        public class Capabilities : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 101; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.Capabilities(), "CAPABILITIES");
            }

            [Fact]
            public void CanExecuteWithKeywordParameter()
            {
                Test(x => x.Capabilities("AUTOUPDATE"), "CAPABILITIES AUTOUPDATE");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class ModeReader : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.ModeReader(), "MODE READER");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Quit : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.Quit(), "QUIT");
            }
        }
    }
}