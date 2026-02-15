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
