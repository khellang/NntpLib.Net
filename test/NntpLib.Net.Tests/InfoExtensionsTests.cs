using System;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class InfoExtensionsTests
    {
        private static readonly DateTime CreatedSince = new DateTime(2013, 9, 10, 18, 23, 10);

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Date : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.Date(), "DATE");
            } 
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Help : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 100; }
            }

            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.Help(), "HELP");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class NewGroups : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 231; }
            }

            [Fact]
            public void CanExecuteWithCreatedSinceParameter()
            {
                Test(x => x.NewGroups(CreatedSince), "NEWGROUPS 20130910 182310");
            }

            [Fact]
            public void ShouldIncludeGmtParameterWhenIsGmtIsTrue()
            {
                Test(x => x.NewGroups(CreatedSince, true), "NEWGROUPS 20130910 182310 GMT");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class NewNews : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 230; }
            }

            [Fact]
            public void CanExecuteWithCreatedSinceAndWildmatParameter()
            {
                Test(x => x.NewNews(CreatedSince, "alt.*"), "NEWNEWS alt.* 20130910 182310");
            }

            [Fact]
            public void ShouldThrowIfWildmatIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.NewNews(DateTime.Now, null));
            }

            [Fact]
            public void ShouldIncludeGmtParameterWhenIsGmtIsTrue()
            {
                Test(x => x.NewNews(CreatedSince, "alt.*", true), "NEWNEWS alt.* 20130910 182310 GMT");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class List : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 215; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.List(), "LIST");
            }

            [Fact]
            public void CanExecuteWithKeywordParameter()
            {
                Test(x => x.List(ListKeyword.Active), "LIST ACTIVE");
            }

            [Fact]
            public void CanExecuteWithKeywordAndWildmatParameters()
            {
                Test(x => x.List(ListKeyword.Active, "alt.*"), "LIST ACTIVE alt.*");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Over : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 224; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.Over(), "OVER");
            }

            [Fact]
            public void CanExecuteWithMessageIdParameter()
            {
                Test(x => x.Over("1234213"), "OVER <1234213>");
            }

            [Fact]
            public void CanExecuteWithArticleNumberParameter()
            {
                Test(x => x.Over(1234), "OVER 1234");
            }

            [Fact]
            public void CanExecuteWithRangeParameter()
            {
                Test(x => x.Over(Range.From(1234).To(2345)), "OVER 1234-2345");
            }

            [Fact]
            public void ShouldThrowIfMessageIdIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Over((string) null));
            }

            [Fact]
            public void ShouldThrowIfRangeIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Over((Range) null));
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Hdr : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 225; }
            }

            [Fact]
            public void CanExecuteOnlyFieldParameter()
            {
                Test(x => x.Hdr(":bytes"), "HDR :bytes");
            }

            [Fact]
            public void CanExecuteWithMessageIdParameter()
            {
                Test(x => x.Hdr(":bytes", "1234213"), "HDR :bytes <1234213>");
            }

            [Fact]
            public void CanExecuteWithArticleNumberParameter()
            {
                Test(x => x.Hdr(":bytes", 1234), "HDR :bytes 1234");
            }

            [Fact]
            public void CanExecuteWithRangeParameter()
            {
                Test(x => x.Hdr(":bytes", Range.From(1234).To(2345)), "HDR :bytes 1234-2345");
            }

            [Fact]
            public void ShouldThrowIfFieldIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Hdr(null));
            }

            [Fact]
            public void ShouldThrowIfMessageIdIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Hdr(":bytes", (string) null));
            }

            [Fact]
            public void ShouldThrowIfRangeIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Hdr(":bytes", (Range) null));
            }
        }
    }
}