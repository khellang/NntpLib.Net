using Should;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class RangeTests
    {
        public class From
        {
            [Fact]
            public void ShouldReturnRangeFromGivenArticleId()
            {
                Range.From(1234).ToString().ShouldEqual("1234-");
            } 
        }

        public class To
        {
            [Fact]
            public void ShouldReturnRangeBetweenGivenArticleIds()
            {
                Range.From(1234).To(2345).ToString().ShouldEqual("1234-2345");
            } 
        }
    }
}