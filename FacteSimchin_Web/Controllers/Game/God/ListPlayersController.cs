using FacteSimchin_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacteSimchin_Web.Controllers.Game.God
{
    [Route("game/god/listplayers")]
    public class ListPlayersController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        public async Task<IActionResult> Index(string sessionId, string godSecret)
        {
            if (!await _db.GameSessions
                .AsNoTracking()
                .AnyAsync(g => g.SessionId == sessionId && g.Secret == godSecret))
                return NotFound($"بازی با شناسه {sessionId} یافت نشد یا شما اجازه دسترسی ندارید چون راوی بازی نیستید.");
            return View(new ListPlayersViewModel() { SessionId = sessionId, });
        }
    }
}
