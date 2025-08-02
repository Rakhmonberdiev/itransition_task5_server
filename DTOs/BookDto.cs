namespace itransition_task5_server.DTOs
{
    public sealed class BookDto
    {
        public int Index { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new List<string>();
        public string Publisher { get; set; } = string.Empty;
        public int Likes { get; set; }
        public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
