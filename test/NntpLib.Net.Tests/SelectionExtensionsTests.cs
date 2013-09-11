using System;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class SelectionExtensionsTests
    {
        [Trait("Category", "RFC 3977 - NNTP")]
        public class Group : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.Group("alt.group.com"), "GROUP alt.group.com");
            }

            [Fact]
            public void ShouldThrowIfGroupIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.Group(null));
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class ListGroup : MultilineCommandTest
        {
            protected override int ValidResponseCode
            {
                get { return 211; }
            }

            [Fact]
            public void CanExecuteWithoutParameters()
            {
                Test(x => x.ListGroup(), "LISTGROUP");
            }

            [Fact]
            public void CanExecuteWithGroupParameter()
            {
                Test(x => x.ListGroup("alt.group.com"), "LISTGROUP alt.group.com");
            }

            [Fact]
            public void ShouldThrowIfGroupIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.ListGroup(null, 1234));
            }

            [Fact]
            public void CanExecuteWithGroupAndArticleIdParameters()
            {
                Test(x => x.ListGroup("alt.group.com", 1234), "LISTGROUP alt.group.com 1234");
            }

            [Fact]
            public void CanExecuteWithGroupAndRangeParameters()
            {
                Test(x => x.ListGroup("alt.group.com", Range.From(1234).To(2345)), "LISTGROUP alt.group.com 1234-2345");
            }
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Last : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.Last(), "LAST");
            } 
        }

        [Trait("Category", "RFC 3977 - NNTP")]
        public class Next : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.Next(), "NEXT");
            } 
        }
    }
}