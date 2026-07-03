using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacteSimchin_Web.Models
{
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required GameSessionModel GameSession { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
    }
}
