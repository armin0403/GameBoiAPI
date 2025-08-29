using Microsoft.AspNetCore.Mvc;

namespace GameBoiAPI.Controllers
{
    public class ChallangesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
