using FacteSimchin_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacteSimchin_Web.Controllers.Api.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameFunctionsController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        [HttpPost("testapi")]
        public async Task<IActionResult> TestApi()
        {
            await _db.GameSessions.AddAsync(new GameSessionModel() { SessionId = Guid.NewGuid().ToString(), GodName = "مهربد" });
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
