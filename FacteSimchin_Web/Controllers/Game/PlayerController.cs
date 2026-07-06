using FacteSimchin_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacteSimchin_Web.Controllers.Game
{
    [Route("game/[controller]")]
    public class PlayerController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        [Route("joinsession")]
        public async Task<IActionResult> JoinSession(string sessionId)
        {
            GameSessionModel? gameSession = await _db.GameSessions
                .FirstOrDefaultAsync(x => x.SessionId == sessionId);
            if (gameSession == null)
                return BadRequest($"شناسه بازی '{sessionId}' یافت نشد.");
            return View(new JoinSessionViewModel() { SessionId = gameSession.SessionId, GodName = gameSession.GodName });
        }

        public async Task<IActionResult> LeaveSession(string sessionId)
        {
            return View();
        }
    }
}
