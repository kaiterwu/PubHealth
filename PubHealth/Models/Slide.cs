using System.ComponentModel.DataAnnotations.Schema;

namespace PubHealth.Models
{
    public class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public bool IsFork { get; set; }
        public string? SlideText { get; set; } = string.Empty;
        public string? QuestionText { get; set; } = string.Empty;
        public string? ExplanationText { get; set; } = string.Empty;
        public string? SlideImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

    }
}
