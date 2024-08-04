using AltronFormsAPI.Models;
using AltronFormsAPI.Server.Data;
using AltronFormsAPI.Server.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AltronFormsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult GetAllLogins()
        {
            var allLogins = dbContext.Login.ToList();

            return Ok(allLogins);
        }

        [HttpPost]

        public async Task<ActionResult<Login>> AddLogin(addLoginDto _addloginDto)
        {
            var maxLoginID = await dbContext.Login.MaxAsync(u => (int)u.LoginID);

            var loginEntity = new Login()
            {
                Email = _addloginDto.email,
                PasswordHash = _addloginDto.password,
            };

            dbContext.Login.Add(loginEntity);
            dbContext.SaveChanges(); 
            return Ok(loginEntity);
        }
    }
}
