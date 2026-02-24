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
            // this creates a new viewmodel object for the dashboard view. 
            // with the information from the seeded database. _context.Entries, _context.Hints...
            var vm = new DashboardViewModel()
            {
                // add models needed for the dashboard, 
                // entry, and hints. 
                Entries = _context.Entries.ToList(),
                Hints = _context.Hints.ToList(),
            };


            return View(vm);
        }

        /// <summary>
        /// This method allows the user to ADD a new entry to their 
        /// Project Dungbeetle entry journal
        /// </summary>
        /// <returns></returns>
        [HttpPost] // create and post entry to the database
        public IActionResult AddEntry()
        {
            var vm = new DashboardViewModel();
            return View();
        }

        /// <summary>
        /// This method allows the user to UPDATE a selected entry in their 
        /// Project Dungbeetle entry journal
        /// </summary>
        /// <returns></returns>
        [HttpPost] // create and post entry to the database
        public IActionResult UpdateEntry()
        {
            var vm = new DashboardViewModel();
            return View();
        }

        /// <summary>
        /// This method allows the user to DELETE a selected entry in their 
        /// Project Dungbeetle entry journal
        /// </summary>
        /// <returns></returns>
        [HttpPost] // create and post entry to the database
        public IActionResult DeleteEntry()
        {
            var vm = new DashboardViewModel();
            return View();
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
