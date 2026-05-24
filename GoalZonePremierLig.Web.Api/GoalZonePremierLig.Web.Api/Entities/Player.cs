using System.ComponentModel.DataAnnotations;

namespace GoalZonePremierLig.Web.Api.Entities
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string NameSurname { get; set; }
        public string Nickname { get; set; }
        public string ImageUrl { get; set; } 
        public string Role { get; set; } 

        public int Goals { get; set; }
        public int KeyPasses { get; set; }

        public bool IsTopTier { get; set; } 
        public bool Status { get; set; } 

        public int TeamId { get; set; } 
        public Team Team { get; set; }

        public List<MatchEvents> MatchEvents { get; set; } 
    }
}

