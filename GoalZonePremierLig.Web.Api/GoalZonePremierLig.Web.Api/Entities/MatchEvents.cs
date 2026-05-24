using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.RegularExpressions;

namespace GoalZonePremierLig.Web.Api.Entities
{
    public class MatchEvents
    {
        [Key]
        public int MatchEventId { get; set; }
        public int FixtureId { get; set; }
        public int TeamId { get; set; }
        public int? PlayerId { get; set; }
        public int Minute { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
        public Fixture Fixture { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}
