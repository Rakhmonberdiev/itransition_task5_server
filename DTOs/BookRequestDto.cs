namespace itransition_task5_server.DTOs
{
    public sealed class BookRequestDto
    {
        public string Locale { get; set; } = "en";
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public int Seed { get; set; } = 123;
        public double AvgLikes { get; set; } = 0;
        public double AvgReviews { get; set; } = 0;
    }
}
