using System.ComponentModel.DataAnnotations;

namespace AltronFormsAPI.Models.Entities
{
    public class Questions
    {
        [Key]
        public int QuestionID { get; set; }

        public int QuestionnaireID { get; set; }

        public required string QuestionText {  get; set; }

        public required string QuestionType { get; set; }

        public required string IsRequired { get; set; }
    }
}
