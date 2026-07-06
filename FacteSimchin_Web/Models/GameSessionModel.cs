using System.ComponentModel.DataAnnotations;

namespace FacteSimchin_Web.Models
{
    public class GameSessionModel
    {
        [Key]
        public required string SessionId { get; set; }

        public required string GodName { get; set; }

        public required string Secret { get; set; }

        public List<PlayerModel> Players { get; set; } = [];

        public required bool AcceptsNewPlayers { get; init; }
    }
}
