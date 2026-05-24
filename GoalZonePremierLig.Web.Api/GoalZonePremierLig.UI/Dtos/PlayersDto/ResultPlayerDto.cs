namespace GoalZonePremierLig.Web.Api.Dtos.PlayersDto
{
    public class ResultPlayerDto
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string ImageUrl { get; set; }
        public string Position { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public bool IsStarPlayer { get; set; }
        public bool IsActive { get; set; }
        public int TeamId { get; set; }
    }
}

