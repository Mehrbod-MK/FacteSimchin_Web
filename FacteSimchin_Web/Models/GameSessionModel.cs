using System.ComponentModel.DataAnnotations;

namespace FacteSimchin_Web.Models
{
    public class GameSessionModel
    {
        [Key]
        public required string SessionId { get; set; }

        public required string GodName { get; set; }

        public required string Secret { get; set; }
    }
}
