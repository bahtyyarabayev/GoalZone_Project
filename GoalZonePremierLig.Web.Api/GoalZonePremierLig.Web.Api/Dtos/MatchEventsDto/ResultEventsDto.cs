namespace GoalZonePremierLig.Web.Api.Dtos.MatchEventsDto
{
    public class ResultEventsDto
    {
        public int MatchEventId { get; set; }
        public int FixtureId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }
        public string PlayerName { get; set; }
        public string PlayerImageUrl { get; set; }
        public int Minute { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
    }
}
