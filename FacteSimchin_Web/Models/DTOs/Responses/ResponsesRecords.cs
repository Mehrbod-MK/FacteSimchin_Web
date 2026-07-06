namespace FacteSimchin_Web.Models.DTOs.Responses
{
    public static class ResponsesRecords
    {
        public record NewGameInfosResponseDto(string SessionId, string GodSecret);

        public record PlayerIdNameInfoDto(int Id, string Name);
        public record GetListJoinedPlayerNamesDto(IEnumerable<PlayerIdNameInfoDto> Players);
    }
}
