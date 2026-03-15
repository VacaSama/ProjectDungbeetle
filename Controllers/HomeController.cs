using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectDungbeetle.Models;
using ProjectDungbeetle.ViewModels;
using ProjectDungbeetle.Data;
using Microsoft.IdentityModel.Tokens;

namespace ProjectDungbeetle.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// A readonly field that holds the database context for the application. 
        /// </summary>
        private readonly DungbeetleDbContext _context;

        /// <summary>
        /// This is a constructor fo the HomeController class to retieve the database context.
        /// </summary>
        /// <param name="context"></param>
        public HomeController(DungbeetleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notes = _context.GeneralNotes.FirstOrDefault();

            // this creates a new viewmodel object for the dashboard view. 
            // with the information from the seeded database. _context.Entries, _context.Hints...
            var vm = new DashboardViewModel()
            {
                // add models needed for the dashboard, 
                // entry, and hints. 
                Entries = _context.Entries.ToList(),
                Hints = _context.Hints.ToList(),
                Questionnaire = _context.Questionnaires.ToList(),
                UserResponse = _context.QuestionnaireResponses.ToList(),
                GeneralNotes = notes?.NotesContent
            };
            return View(vm);
        }

        /// <summary>
        /// This method allows the user to ADD a new entry to their 
        /// Project Dungbeetle entry journal
        /// </summary>
        /// <returns></returns>
        [HttpPost] // create and post entry to the database
        public IActionResult AddEntry(DashboardViewModel vm)
        {
            var entry = new Entry
            {
                Title = vm.Entry.Title,
                ErrorDescription = vm.Entry.ErrorDescription,
                CodingLanguage = vm.Entry.CodingLanguage,
                CodeSnippet = vm.Entry.CodeSnippet,
                Notes = vm.Entry.Notes,
                CreatedAt = DateTime.Now,
            };

            _context.Entries.Add(entry);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This method allows the user to UPDATE a selected entry in their 
        /// Project Dungbeetle entry journal
        /// </summary>
        /// <returns></returns>
        [HttpPost] // create and post entry to the database
        public IActionResult UpdateEntry(DashboardViewModel vm)
        {
            if (!ModelState.IsValid){
                return View("Index", vm);
            }

            var entry = _context.Entries.FirstOrDefault(e => e.Id == vm.Entry.Id);
            if (entry == null)
            {
                throw new Exception("No entry was found");
            }
            // Update the properties
            entry.Title = vm.Entry.Title;
            entry.CodingLanguage = vm.Entry.CodingLanguage;
            entry.CodeSnippet = vm.Entry.CodeSnippet;
            entry.ErrorDescription = vm.Entry.ErrorDescription;
            entry.Notes = vm.Entry.Notes;
            entry.CreatedAt = DateTime.Now;    

            _context.Entries.Update(entry);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        /// <summary>
        /// Retrieves the entry with the specified identifier and returns it as a JSON result.
        /// </summary>
        /// <param name="id">The unique identifier of the entry to retrieve.</param>
        /// <returns>A JSON result containing the entry with the specified identifier, or null if no such entry exists.</returns>
        public IActionResult GetEntry(int id)
        {
            var entry = _context.Entries.FirstOrDefault(e => e.Id == id);
            return Json(entry);
        }

        /// <summary>
        /// This method allows the user to DELETE a selected entry in their 
        /// Project Dungbeetle entry journal
        /// </summary>
        /// <returns></returns>
        [HttpPost] // create and post entry to the database
        public IActionResult DeleteEntry(int id)
        {
            
            var entry = _context.Entries.FirstOrDefault(e => e.Id == id); 
            if (entry == null)
            {
                throw new Exception("Could not delete entry, deletion error");
            }

            _context.Entries.Remove(entry);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This method contains logic both used for the dropdown and the search tool 
        /// in the navbar and allows users to filter through their entries: Newest, Oldest
        /// or Default (Newest). It also allows the use to search through their entries 
        /// for keywords within their notes, error descriptions and entry titles. 
        /// </summary
        /// <param name="sort"></param>
        /// <param name="search"></param>
        /// <returns></returns>

        [HttpGet] // retrieve the filter/search wanted 
        public IActionResult SortSearch(string sort, string search)
        {
            var entriesQuery = _context.Entries.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                entriesQuery = entriesQuery.Where(e =>
                    e.Title.Contains(search) ||
                    e.ErrorDescription.Contains(search) ||
                    e.Notes.Contains(search));
            }

            // Switch case for the dropdown 
            switch (sort)
            {
                case "newest":
                    entriesQuery = entriesQuery.OrderByDescending(e => e.CreatedAt);
                    break;

                case "oldest":
                    entriesQuery = entriesQuery.OrderBy(e => e.CreatedAt);
                    break;

                default:
                    entriesQuery = entriesQuery.OrderByDescending(e => e.CreatedAt);
                    break;
            }

            var vm = new DashboardViewModel
            {
                Entries = entriesQuery.ToList(),
            };

            return View("Index", vm);
        }

        /// <summary>
        /// This method contains logic for the user to save general notes on the dashboard, 
        /// these are free form notes that the user can use to jot down any thoughts, ideas, or reminders they want to keep track of. 
        /// </summary>
        /// <returns></returns>
        public IActionResult SaveGeneralNotes(string content)
        {
            var note = _context.GeneralNotes.FirstOrDefault();

            if (note == null)
            {
                note = new GeneralNotes { NotesContent = content };
                _context.GeneralNotes.Add(note);
            }
            else
            {
                note.NotesContent = content;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult SaveQuestionnaire(IFormCollection form)
        {
            var profile = _context.UserProfiles.FirstOrDefault();

            foreach (var key in form.Keys)
            {
                if (!key.StartsWith("q-"))
                    continue;

                int questionId = int.Parse(key.Replace("q-", ""));
                string answer = form[key];

                var existing = _context.QuestionnaireResponses
                    .FirstOrDefault(r => r.QuestionId == questionId && r.UserProfileId == profile.Id);

                if (existing == null)
                {
                    _context.QuestionnaireResponses.Add(new QuestionnaireResponse
                    {
                        QuestionId = questionId,
                        UserProfileId = profile.Id,
                        UserResponse = answer
                    });
                }
                else
                {
                    existing.UserResponse = answer;
                }
            }

            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
