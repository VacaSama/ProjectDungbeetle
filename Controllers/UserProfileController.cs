using System.Diagnostics;
using ProjectDungbeetle.Models;
using ProjectDungbeetle.ViewModels;
using ProjectDungbeetle.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDungbeetle.Controllers;

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
        var user = _context.UserProfiles.FirstOrDefault();

        var vm = new UserProfileViewModel()
        {
            FullName = user?.FullName,
            Occupation = user?.Occupation,
            ExperienceLevel = user?.ExperienceLevel,
            QuestionniareData = _context.Questionnaires.ToList(),
            UserResponseData = _context.QuestionnaireResponses.ToList()
        };

        return View(vm);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult SaveProfile(UserProfileViewModel model)
    {
        var profile = _context.UserProfiles.FirstOrDefault();

        if (profile == null)
        {
            profile = new UserProfile();
            _context.UserProfiles.Add(profile);
        }

        profile.FullName = model.FullName;
        profile.Occupation = model.Occupation;
        profile.ExperienceLevel = model.ExperienceLevel;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}