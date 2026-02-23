using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectDungbeetle.Models;
using ProjectDungbeetle.ViewModels;
using ProjectDungbeetle.Data; 

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
        /// This method allows the user to add a new entry to their 
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
        /// This method is attached to the search field in the navbar and allows users to 
        /// search through their entries for keywords within their notes, code snippets, 
        /// error descriptions and entry titles. 
        /// </summary>
        /// <returns></returns>
        public IActionResult SearchBar()
        {
            var vm = new DashboardViewModel();
            return View();
        }

        /// <summary>
        /// This method is attached to the dropdown in the navbar and allows users to 
        /// filter through their entries: Newest, Oldest or Default (Newest)
        /// </summary>
        /// <returns></returns>
        [HttpGet] // retrieve the filter wanted 
        public IActionResult FilterEntry() 
        {
            var vm = new DashboardViewModel();

            return View();
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
