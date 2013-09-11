using System.Collections.Generic;
using System.Linq;

namespace NntpLib.Net
{
    public class NntpClient
    {
        private readonly INntpConnection _connection;

        public NntpClient() : this(new NntpConnection()) { }

        public NntpClient(INntpConnection connection)
        {
            _connection = connection;
        }

        public bool Connect(string hostname, int port, bool useSsl)
        {
            var connectResponse = _connection.Connect(hostname, port, useSsl);
            return connectResponse.Code == 200 || connectResponse.Code == 201;
        }

        public bool Authenticate(string username, string password = null)
        {
            var userResponse = _connection.AuthInfoUser(username);
            
            if (userResponse.Code == 281) return true;

            if (userResponse.Code != 381 || password == null) return false;

            var passResponse = _connection.AuthInfoPass(password);
            
            return passResponse.Code == 281;
        }

        public bool SetReaderMode()
        {
            var response = _connection.ModeReader();
            if (response.Code == 502)
            {
                _connection.Close();
                return false;
            }

            return response.Code == 200 || response.Code == 201;
        }

        public Article RetrieveArticle(string messageId)
        {
            var response = _connection.Article(messageId);
            if (response.Lines == null) return null;

            var articleLines = response.Lines.ToList();

            var headers = articleLines.TakeWhile(x => !string.IsNullOrWhiteSpace(x)).Select(Header.Create);
            var body = articleLines.SkipWhile(x => !string.IsNullOrWhiteSpace(x)).Skip(1).ToList();

            return new Article(headers, body);
        }

        public IEnumerable<Header> RetrieveHeader(string messageId)
        {
            var response = _connection.Head(messageId);
            if (response.Lines == null) return Enumerable.Empty<Header>();

            return response.Lines.Select(Header.Create);
        }
    }

    public class Article
    {
        public Article(IEnumerable<Header> headers, List<string> body)
        {
            Headers = headers;
            Body = body;
        }

        public IEnumerable<Header> Headers { get; private set; }

        public List<string> Body { get; private set; }
    }

    public class Header
    {
        private Header(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Key, Value);
        }

        public static Header Create(string line)
        {
            var parts = line.Split(':');
            return new Header(parts[0], parts[1].Trim(' '));
        }
    }
}