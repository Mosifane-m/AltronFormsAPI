using AltronFormsAPI.Models.Entities;
using AltronFormsAPI.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AltronFormsAPI.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Questionaires> Questionnaires { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Questions> Questions { get; set; }
    }
}
