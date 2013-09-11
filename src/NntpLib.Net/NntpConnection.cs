using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace NntpLib.Net
{
    public class NntpConnection : INntpConnection
    {
        private static readonly Encoding Encoding = Encoding.GetEncoding("iso-8859-1");

        private readonly TcpClient _client = new TcpClient();

        private NntpStreamReader _reader;

        private StreamWriter _writer;

        public bool IsConnected
        {
            get { return _client.Connected; }
        }

        public NntpResponse Connect(string hostname, int port, bool useSsl)
        {
            _client.Connect(hostname, port);

            var stream = GetStream(hostname, useSsl);

            _reader = new NntpStreamReader(stream, Encoding);
            _writer = new StreamWriter(stream, Encoding) { AutoFlush = true };

            return ReadResponse((code, message) => new NntpResponse(code, message));
        }

        public NntpResponse ExecuteCommand(string command)
        {
            EnsureConnected();

            return ExecuteCommand(command, (code, message) => new NntpResponse(code, message));
        }

        public NntpMultilineResponse ExecuteMultilineCommand(string command, int validCode)
        {
            EnsureConnected();

            return ExecuteCommand(command, (code, message) => new NntpMultilineResponse(code, message, code == validCode ? _reader.ReadAllLines() : null));
        }

        private void EnsureConnected()
        {
            if (!IsConnected) throw new NntpException("Must be connected to execute commands.");
        }

        public void Close()
        {
            _client.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            _reader.Dispose();
            _reader = null;

            _writer.Dispose();
            _writer = null;
        }

        private TResponse ExecuteCommand<TResponse>(string command, Func<int, string, TResponse> responseFunc)
        {
            _writer.WriteLine(command);
            return ReadResponse(responseFunc);
        }

        private TResponse ReadResponse<TResponse>(Func<int, string, TResponse> responseFunc)
        {
            var responseText = _reader.ReadLine();
            if (responseText == null)
            {
                throw new NntpException("Did not receive response from server.");
            }

            int code;
            if (!int.TryParse(responseText.Substring(0, 3), out code))
            {
                throw new NntpException("Received invalid response from server.");
            }

            return responseFunc(code, responseText.Substring(4));
        }

        private Stream GetStream(string hostname, bool useSsl)
        {
            Stream stream = _client.GetStream();
            if (!useSsl) return stream;

            var sslStream = new SslStream(stream);
            sslStream.AuthenticateAsClient(hostname);

            return sslStream;
        }
    }
}