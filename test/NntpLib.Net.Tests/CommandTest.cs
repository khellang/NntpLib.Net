using System;

using FakeItEasy;

namespace NntpLib.Net.Tests
{
    public abstract class CommandTest
    {
        protected CommandTest()
        {
            Connection = A.Fake<INntpConnection>();
        }

        protected INntpConnection Connection { get; private set; }

        protected virtual void Test(Action<INntpConnection> action, string expectedCommand)
        {
            action(Connection);

            A.CallTo(() => Connection.ExecuteCommand(expectedCommand));
        }
    }
}