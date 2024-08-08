namespace AltronFormsAPI.Models
{
    public class addQuestionaireDto
    {
        public required int UserID { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Published {  get; set; }
    }
}
