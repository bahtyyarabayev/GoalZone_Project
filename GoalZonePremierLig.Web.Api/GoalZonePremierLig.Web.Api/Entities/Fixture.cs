using System.ComponentModel.DataAnnotations;

namespace GoalZonePremierLig.Web.Api.Entities
{
    public class Fixture
    {
        [Key]
        public int FixtureId { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public string Week { get; set; }
        public string Status { get; set; }
        public int Minute { get; set; }
        public bool IsFeatured { get; set; } 
        public List<MatchEvents> MatchEvents { get; set; }
    }
}
