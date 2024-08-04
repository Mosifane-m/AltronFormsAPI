using AltronFormsAPI.Models.Entities;
using AltronFormsAPI.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AltronFormsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnairesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public QuestionnairesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{UserID}")]

        public IActionResult GetAllQuestionnaires(int UserID)
        {
            List<Questionaires> UserQuestionaires = new List<Questionaires>();

            var allQuestionaires = dbContext.Questionnaires.ToList();

            foreach (var item in allQuestionaires)
            {
                if (item.UserID == UserID)
                {
                    UserQuestionaires.Add(item);
                }
            }

            return Ok(UserQuestionaires);
        }
    }
}
