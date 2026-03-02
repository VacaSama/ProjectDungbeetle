using Microsoft.AspNetCore.Mvc;

namespace ProjectDungbeetle.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
