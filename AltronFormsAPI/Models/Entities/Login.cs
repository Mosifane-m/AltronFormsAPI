namespace AltronFormsAPI.Server.Models.Entities
{
    public class Login
    {
        public int LoginID { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }
    }
}
