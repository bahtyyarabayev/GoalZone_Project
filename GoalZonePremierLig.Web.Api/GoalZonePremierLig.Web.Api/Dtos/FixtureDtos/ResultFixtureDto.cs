using GoalZonePremierLig.Web.Api.Entities;

namespace GoalZonePremierLig.Web.Api.Dtos.FixtureDtos
{
    public class ResultFixtureDto
    {
        public int MatchId { get; set; }

        public string HomeTeam { get; set; }
        public string HomeLogoUrl { get; set; }

        public string AwayTeam { get; set; }
        public string AwayLogoUrl { get; set; }

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
