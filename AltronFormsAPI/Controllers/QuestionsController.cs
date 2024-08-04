using AltronFormsAPI.Models.Entities;
using AltronFormsAPI.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AltronFormsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        
        public QuestionsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{QuestionaireID}")]

        public IActionResult getQuestions(int QuestionaireID)
        {
            List<Questions> userQuestions = new List<Questions>();

            var allQuestions = dbContext.Questions.ToList();

            foreach (var question in allQuestions)
            {
                if (question.QuestionnaireID == QuestionaireID)
                {
                    userQuestions.Add(question);
                }
            }

            return Ok(userQuestions);
        }
    }
}
