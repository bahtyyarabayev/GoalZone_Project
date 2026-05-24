namespace GoalZonePremierLig.Web.Api.Dtos.FixtureDtos
{
    public class FeaturedDto
    {
        public int MatchId { get; set; }

        public string HomeTeam { get; set; }
        public string HomeLogoUrl { get; set; }

        public string AwayTeam { get; set; }
        public string AwayLogoUrl { get; set; }

        public DateTime MatchDate { get; set; }

        public string Week { get; set; }

        public string Stadium { get; set; }
    }
}
