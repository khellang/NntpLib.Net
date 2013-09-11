using System;

namespace NntpLib.Net
{
    public class PullRequestException : NotImplementedException
    {
        public PullRequestException() : base("I'm too lazy to implement this. Submit a PR at github.com/khellang/NntpLib.Net :)") { }
    }
}