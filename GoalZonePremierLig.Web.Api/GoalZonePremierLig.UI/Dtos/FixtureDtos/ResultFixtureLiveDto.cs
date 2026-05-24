namespace GoalZonePremierLig.Web.Api.Dtos.FixtureDtos
{
    public class ResultFixtureLiveDto
    {
        public int MatchId { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public int Minute { get; set; }
    }
}
