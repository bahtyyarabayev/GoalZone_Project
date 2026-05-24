namespace GoalZonePremierLig.Web.Api.Dtos.FixtureDtos
{
    public class CreateFixtureDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public string Week { get; set; }
        public string Status { get; set; }
        public int Minute { get; set; }
        public bool IsFeatured { get; set; }
    }
}
