namespace NntpLib.Net
{
    public class NntpResponse
    {
        internal NntpResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; private set; }

        public string Message { get; private set; }
    }
}