using System;

using Xunit;

namespace NntpLib.Net.Tests
{
    public class AuthExtensionsTests
    {
        [Trait("Category", "RFC 4643 - NNTP-AUTH")]
        public class AuthInfoUser : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.AuthInfoUser("username"), "AUTHINFO USER username");
            }

            [Fact]
            public void ShouldThrowIfUsernameIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.AuthInfoUser(null));
            }
        }

        [Trait("Category", "RFC 4643 - NNTP-AUTH")]
        public class AuthInfoPass : CommandTest
        {
            [Fact]
            public void ShouldExecuteCorrectCommand()
            {
                Test(x => x.AuthInfoPass("password"), "AUTHINFO PASS password");
            }

            [Fact]
            public void ShouldThrowIfUsernameIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Connection.AuthInfoPass(null));
            }
        }
    }
}