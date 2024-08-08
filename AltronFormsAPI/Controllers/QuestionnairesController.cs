using AltronFormsAPI.Models;
using AltronFormsAPI.Models.Entities;
using AltronFormsAPI.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        [HttpPost]

        public IActionResult AddQuestionaire(addQuestionaireDto addQuestionaireDto)
        {
            var questionaireEntity = new Questionaires()
            {
                UserID = addQuestionaireDto.UserID,
                Title = addQuestionaireDto.Title,
                Description = addQuestionaireDto.Description,
                Published = "Not Published",
            };

            dbContext.Questionnaires.Add(questionaireEntity);
            dbContext.SaveChanges();


            return Ok(questionaireEntity);
        }
    }
}
