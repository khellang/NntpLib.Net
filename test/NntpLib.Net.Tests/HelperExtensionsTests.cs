using System;

using Should;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class HelperExtensionsTests
    {
        public class GetDescription
        {
            [Fact]
            public void ShouldThrowIfTypeIsNotEnum()
            {
                Assert.Throws<InvalidOperationException>(() => new DateTime().GetDescription());
            }

            [Fact]
            public void ShouldGetDescriptionFromEnumValue()
            {
                ListKeyword.Active.GetDescription().ShouldEqual("ACTIVE");
            }

            [Fact]
            public void ShouldReturnNullIfDescriptionAttributeIsMissing()
            {
                ConsoleKey.Attention.GetDescription().ShouldBeNull();
            }
        }

        public class WithBrackets
        {
            [Fact]
            public void ShouldWrapValueInBrackets()
            {
                "SomeValue".WithBrackets().ShouldEqual("<SomeValue>");
            }

            [Fact]
            public void ShouldNotWrapValueInBracketsIfBracketsExists()
            {
                "<SomeValue>".WithBrackets().ShouldEqual("<SomeValue>");
            }
        }
    }
}