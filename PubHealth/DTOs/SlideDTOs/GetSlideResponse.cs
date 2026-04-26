namespace PubHealth.DTOs.SlideDTOs
{
    public class GetSlideResponse
    {
        public int Id { get; set; }
        public bool IsFork { get; set; }
        public string SlideText { get; set; } = string.Empty;
        public string QuestionText { get; set; } = string.Empty;
        public string ExplanationText { get; set; } = string.Empty;
        public string SlideImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
