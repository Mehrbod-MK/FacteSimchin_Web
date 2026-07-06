using System.Diagnostics.CodeAnalysis;

namespace FacteSimchin_Web.Models
{
    public class ListPlayersViewModel
    {
        public required string SessionId { get; set; }
        public required string GodSecret { get; set; }
    }
}
