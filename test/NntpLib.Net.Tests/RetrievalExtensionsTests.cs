using System;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class RetrievalExtensionsTests
    {
        [Trait("Category", "RFC 3977 - NNTP")]
        public class Article : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 220; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.Article(), "ARTICLE");
            }

            [Fact]
            public void CanExecuteWithMessageIdParameter()
            {
                Test(x => x.Article("1234231"), "ARTICLE <1234231>");
            }

            [Fact]
            public void CanExecuteWithArticleNumberParameter()
            {
                Test(x => x.Article(1234), "ARTICLE 1234");
            }

            [Fact]
            public void ShouldThrowIfMessageIdIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Article((string) null));
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Head : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 221; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.Head(), "HEAD");
            }

            [Fact]
            public void CanExecuteWithMessageIdParameter()
            {
                Test(x => x.Head("1234231"), "HEAD <1234231>");
            }

            [Fact]
            public void CanExecuteWithArticleNumberParameter()
            {
                Test(x => x.Head(1234), "HEAD 1234");
            }

            [Fact]
            public void ShouldThrowIfMessageIdIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Head((string) null));
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Body : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 222; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.Body(), "BODY");
            }

            [Fact]
            public void CanExecuteWithMessageIdParameter()
            {
                Test(x => x.Body("1234231"), "BODY <1234231>");
            }

            [Fact]
            public void CanExecuteWithArticleNumberParameter()
            {
                Test(x => x.Body(1234), "BODY 1234");
            }

            [Fact]
            public void ShouldThrowIfMessageIdIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Body((string) null));
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Stat : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 223; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.Stat(), "STAT");
            }

            [Fact]
            public void CanExecuteWithMessageIdParameter()
            {
                Test(x => x.Stat("1234231"), "STAT <1234231>");
            }

            [Fact]
            public void CanExecuteWithArticleNumberParameter()
            {
                Test(x => x.Stat(1234), "STAT 1234");
            }

            [Fact]
            public void ShouldThrowIfMessageIdIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Stat((string) null));
            }
        }
    }
}