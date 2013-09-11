using System;

using FakeItEasy;

namespace NntpLib.Net.Tests
{
    public abstract class MultilineCommandTest : CommandTest
    {
        protected abstract int ValidResponseCode { get; }

        protected override void Test(Action<INntpConnection> action, string expectedCommand)
        {
            action(Connection);

            A.CallTo(() => Connection.ExecuteMultilineCommand(expectedCommand, ValidResponseCode)).MustHaveHappened();
        }
    }
}