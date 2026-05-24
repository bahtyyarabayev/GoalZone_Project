using System.ComponentModel.DataAnnotations;

namespace GoalZonePremierLig.Web.Api.Entities
{
    public class Standing
    {
        [Key]
        public int StandingId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public int Position { get; set; }
        public string Form { get; set; }
    }
}
