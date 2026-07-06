namespace FacteSimchin_Web.Models.DTOs.Requests
{
    public static class RequestsRecords
    {
        public abstract record RequestsBase(string SessionId);
        
        public abstract record GodRequestsBase(string SessionId, string GodSecret) : RequestsBase(SessionId: SessionId);

        public record NewGameRequestDto(string? GodName = null);
        
        public record GetListJoinedPlayerNamesRequestDto(string SessionId, string GodSecret) : GodRequestsBase(SessionId: SessionId, GodSecret: GodSecret);

        public record PlayerJoinGameSessionRequestDto(string SessionId, string PlayerName) : RequestsBase(SessionId: SessionId);
    }
}
