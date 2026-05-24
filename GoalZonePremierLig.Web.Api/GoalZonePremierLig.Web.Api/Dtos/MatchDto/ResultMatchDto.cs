namespace GoalZonePremierLig.Web.Api.Dtos.MatchDto
{
    public class ResultMatchDto
    {
        public int FixtureId { get; set; }
        public string HomeTeam { get; set; }   
        public string HomeTeamLogoUrl { get; set; }   
        public string AwayTeam { get; set; }   
        public string AwayTeamLogoUrl { get; set; }  
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime MatchDate { get; set; }  
        public string Stadium { get; set; }   
        public string Week { get; set; }   
        public string Status { get; set; }
        public int Minute { get; set; }   
        public bool IsFeatured { get; set; }  
        public int HomeTeamId { get; set; } 
        public int AwayTeamId { get; set; }
    }
}
