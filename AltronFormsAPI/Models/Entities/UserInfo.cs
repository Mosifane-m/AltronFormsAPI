using System.ComponentModel.DataAnnotations;

namespace AltronFormsAPI.Models.Entities
{
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }
        public int LoginID { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
