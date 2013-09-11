using System;

namespace NntpLib.Net
{
    public interface INntpConnection : IDisposable, IFluentInterface
    {
        bool IsConnected { get; }

        NntpResponse Connect(string hostname, int port, bool useSsl);

        NntpResponse ExecuteCommand(string command);

        NntpMultilineResponse ExecuteMultilineCommand(string command, int validCode);

        void Close();
    }
}