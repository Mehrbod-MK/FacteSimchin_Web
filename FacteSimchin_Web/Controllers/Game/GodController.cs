using FacteSimchin_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacteSimchin_Web.Controllers.Game
{
    [Route("[controller]")]
    public class GodController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        [Route("chooseRoles")]
        public async Task<IActionResult> ChooseRoles(string sessionId, string godSecret)
        {
            return View();
        }
    }
}
