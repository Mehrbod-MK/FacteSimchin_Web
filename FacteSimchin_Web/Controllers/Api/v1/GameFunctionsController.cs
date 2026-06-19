using Microsoft.AspNetCore.Mvc;

namespace FacteSimchin_Web.Controllers.Api.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameFunctionsController : Controller
    {
        [HttpPost("newgame")]
        public IActionResult NewGame([FromBody] PlayerRequest player)
        {
            return Json(new { god = player.GodPlayerName });
        }
    }

    public class PlayerRequest
    {
        public string GodPlayerName { get; set; }
    }
}
