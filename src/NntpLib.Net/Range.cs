namespace NntpLib.Net
{
    public class Range 
    {
        private readonly int _fromArticleNo;

        private int? _toArticleNo;

        private Range(int fromArticleNo)
        {
            _fromArticleNo = fromArticleNo;
        }

        public static Range From(int articleNo)
        {
            return new Range(articleNo);
        }

        public Range To(int articleNo)
        {
            _toArticleNo = articleNo;
            return this;
        }

        public override string ToString()
        {
            var range = string.Format("{0}-", _fromArticleNo);

            if (_toArticleNo.HasValue)
            {
                range += _toArticleNo.Value;
            }

            return range;
        }
    }
}