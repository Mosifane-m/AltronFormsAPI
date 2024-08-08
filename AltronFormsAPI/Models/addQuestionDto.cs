namespace AltronFormsAPI.Models
{
    public class addQuestionDto
    {
        public int QuestionnaireID { get; set; }

        public required string QuestionText { get; set; }

        public required string QuestionType { get; set; }

        public required string IsRequired { get; set; }
    }
}
