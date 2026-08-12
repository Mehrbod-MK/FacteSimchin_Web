using FacteSimchin_Web.Models.Enums;

namespace FacteSimchin_Web.Models
{
    public class RoleDefinitionModel
    {
        public required string Name { get; init; }

        public required string Description { get; init; }

        public required bool? IsMafia { get; init; }

        public required bool IsPlural { get; init; }

        public required string AvatarUri { get; init; }
    }
}
