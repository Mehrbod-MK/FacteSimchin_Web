using FacteSimchin_Web.Models;
using FacteSimchin_Web.Models.DTOs.Requests;
using FacteSimchin_Web.Models.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacteSimchin_Web.Controllers.Api.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        [HttpPost("newgame")]
        public async Task<IActionResult> NewGame([FromBody] RequestsRecords.NewGameRequestDto newGameRequest)
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
                AcceptsNewPlayers = true,
            });
            await _db.SaveChangesAsync();
            return Json(new ResponsesRecords.NewGameInfosResponseDto(SessionId: sessionId, GodSecret: godSecret));
        }

        [HttpPost("get_list_joined_player_names")]
        public async Task<IActionResult> GetListJoinedPlayerNames([FromBody] RequestsRecords.GetListJoinedPlayerNamesRequestDto getListJoinedPlayersRequest)
        {
            GameSessionModel? foundGameSession = await _db.GameSessions
                .Include(g => g.Players)
                .FirstOrDefaultAsync(x => x.SessionId == getListJoinedPlayersRequest.SessionId && x.Secret == getListJoinedPlayersRequest.GodSecret);
            if (foundGameSession == null)
                return BadRequest("سشن بازی نامعتبر است.");
            return Json(new ResponsesRecords.GetListJoinedPlayerNamesDto(foundGameSession.Players
                .Select(x => new ResponsesRecords.PlayerIdNameInfoDto(Id: x.Id, Name: x.Name))));
        }

        [HttpPost("join_game_session")]
        public async Task<IActionResult> JoinGameSession([FromBody] RequestsRecords.PlayerJoinGameSessionRequestDto playerJoinGameSessionRequest)
        {
            GameSessionModel? foundGameSession = await _db.GameSessions
                .Include(g => g.Players)
                .FirstOrDefaultAsync(x => x.SessionId == playerJoinGameSessionRequest.SessionId);
            if (foundGameSession == null)
                return BadRequest("سشن بازی نامعتبر است.");
            if (!foundGameSession.AcceptsNewPlayers)
                return BadRequest("بازی شروع شده است و بازیکن جدید نمی‌پذیرد.");
            if (string.IsNullOrWhiteSpace(playerJoinGameSessionRequest.PlayerName))
                return BadRequest("نام بازیکن وارد نشده است.");
            PlayerModel? joinedPlayer;
            joinedPlayer = foundGameSession.Players.SingleOrDefault(x => x.Name == playerJoinGameSessionRequest.PlayerName);
            if(joinedPlayer != null)
                return BadRequest($"بازیکن '{playerJoinGameSessionRequest.PlayerName}' قبلاً وارد شده است.");
            joinedPlayer = new()
            {
                GameSession = foundGameSession,
                Name = playerJoinGameSessionRequest.PlayerName,
            };
            foundGameSession.Players.Add(joinedPlayer);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
