using System.ComponentModel.DataAnnotations;

namespace AltronFormsAPI.Models.Entities
{
    public class Questionaires
    {
        [Key]
        public int QuestionnaireID { get; set; }
        public int UserID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Published { get; set; }
    }
}
