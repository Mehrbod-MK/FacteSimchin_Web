using FacteSimchin_Web.Models;
using FacteSimchin_Web.Models.DTOs.Requests;
using FacteSimchin_Web.Models.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FacteSimchin_Web.Controllers.Api.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        [HttpPost("newgame")]
        public async Task<IActionResult> NewGame([FromBody] NewGameRequestDto newGameRequest)
        {
            if (string.IsNullOrWhiteSpace(newGameRequest.GodName))
                return BadRequest("نام گاد بازی وارد نشده است. لطفاً نام گاد یا راوی بازی را وارد کنید.");
            string sessionId = Guid.NewGuid().ToString();
            string godSecret = MlkPwgen.PasswordGenerator.Generate();
            await _db.GameSessions.AddAsync(new GameSessionModel() 
            { 
                SessionId = sessionId, 
                GodName = newGameRequest.GodName,
                Secret = godSecret,
            });
            await _db.SaveChangesAsync();
            return Json(new NewGameInfosResponseDto() { SessionId = sessionId, GodSecret = godSecret, });
        }
    }
}
