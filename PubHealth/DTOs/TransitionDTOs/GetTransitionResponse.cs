using System.ComponentModel.DataAnnotations.Schema;

namespace PubHealth.DTOs.TransitionDTOs
{
    public class GetTransitionResponse
    {
        public int Id { get; set; }
        public int ParentSlideId { get; set; }
        public int ChildSlideId { get; set; }
        public bool IsCorrectChoice { get; set; }   
        public string AnswerText1 { get; set; } = string.Empty;
    }

}

