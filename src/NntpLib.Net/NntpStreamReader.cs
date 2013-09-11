using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NntpLib.Net
{
    internal class NntpStreamReader : StreamReader
    {
        public NntpStreamReader(Stream stream, Encoding encoding) : base(stream, encoding, true) { }

        public IEnumerable<string> ReadAllLines()
        {
            var lines = new List<string>();

            string readLine;
            while ((readLine = ReadLine()) != null)
            {
                if (readLine == ".") break;

                if (readLine.StartsWith(".."))
                    readLine = readLine.Substring(1);

                lines.Add(readLine);
            }

            return lines;
        }
    }
}