using System.Diagnostics;
using ProjectDungbeetle.Models;
using ProjectDungbeetle.ViewModels;
using ProjectDungbeetle.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDungbeetle.Controllers
{
    public class UserProfileController : Controller
    {
        /// <summary>
        /// A readonly field that holds the database context for the application. 
        /// </summary>
        private readonly DungbeetleDbContext _context;

        /// <summary>
        /// This is a constructor fo the UserProfileController class to retieve the database context.
        /// </summary>
        /// <param name="context"></param>
        public UserProfileController(DungbeetleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Retrieves the questions from the database for the user to answer
        // or view
        [HttpGet]
        public IActionResult getQuestions()
        {
            // get the questions from the DB
            var questions = _context.Questionnaires.
                OrderBy(q => q.QuestionText).
                ToList();

            return Json(questions);
        }
    }
}
