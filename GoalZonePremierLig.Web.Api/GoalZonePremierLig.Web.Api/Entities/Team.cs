using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.RegularExpressions;

namespace GoalZonePremierLig.Web.Api.Entities
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoUrl { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public bool IsActive { get; set; }
        public List<Standing> Standings { get; set; }
        public List<Player> Players { get; set; }
        public List<Fixture> HomeMatches { get; set; }
        public List<Fixture> AwayMatches { get; set; }
        public List<MatchEvents> MatchEvents { get; set; }
    }
}
