using System;

namespace NntpLib.Net
{
    public class NntpException : Exception
    {
        public NntpException(string message) : base(message) { }
    }
}