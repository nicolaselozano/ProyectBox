namespace RateLimitMetadata
{    public class IRateLimitMetadata
    {
        public int PermitLimit { get; set; }
        public TimeSpan Window { get; set; }
    }
}

