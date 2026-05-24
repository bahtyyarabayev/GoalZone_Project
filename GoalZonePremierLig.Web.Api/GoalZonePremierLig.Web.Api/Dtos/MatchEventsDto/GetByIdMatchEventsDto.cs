namespace GoalZonePremierLig.Web.Api.Dtos.MatchEventsDto
{
    public class GetByIdMatchEventsDto
    {
        public int MatchEventId { get; set; }

        public int FixtureId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public int Minute { get; set; }

        public string EventType { get; set; }
        public string Description { get; set; }
    }
}
