using System.ComponentModel.DataAnnotations.Schema;
namespace PubHealth.Models
{
    public class Transition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ParentSlideId { get; set; }
        public int ChildSlideId { get; set; }
        public string AnswerText1 { get; set; } = string.Empty;
        public string AnswerText2 { get; set; } = string.Empty;
    }
}
