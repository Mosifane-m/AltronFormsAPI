using AltronFormsAPI.Models;
using AltronFormsAPI.Models.Entities;
using AltronFormsAPI.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AltronFormsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserInfoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{LoginID}")]
        public IActionResult GetUserInfo(int LoginID)
        {
           List<UserInfo> UserInfo = new List<UserInfo>();

            var allUsersInfo = dbContext.UserInfo.ToList();

            foreach (var item in allUsersInfo)
            {
                if (item.LoginID == LoginID)
                {
                    UserInfo.Add(item);
                }
            }

            return Ok(UserInfo);
        }

        [HttpPost]

        public async Task<ActionResult<UserInfo>> PostUserInfo(addUserInfoDto _addUserInfoDto)
        {
            var maxUserID = await dbContext.UserInfo.MaxAsync(u => (int)u.UserID);
            var maxLoginID = await dbContext.Login.MaxAsync(u => (int)u.LoginID);

            var userInfoEntity = new UserInfo()
            {
                UserID = maxUserID + 1,
                LoginID = maxLoginID,
                FullName = _addUserInfoDto.FullName,
                LastName = _addUserInfoDto.LastName,
                Gender = _addUserInfoDto.Gender,
                RegistrationDate = DateTime.Now,
            };

            dbContext.UserInfo.Add(userInfoEntity);
            dbContext.SaveChanges();

            return Ok(userInfoEntity);

        }
    }
}
