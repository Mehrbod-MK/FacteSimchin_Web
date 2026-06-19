using Microsoft.AspNetCore.Mvc;

namespace FacteSimchin_Web.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
