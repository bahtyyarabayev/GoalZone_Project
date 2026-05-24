namespace GoalZonePremierLig.Web.Api.Dtos.MatchStatisticDto
{
    public class ResultStatisticDto
    {
       
        public string HomeTeamName { get; set; }
        public string HomeTeamLogo { get; set; }
        public double HomePossession { get; set; }
        public int HomeShots { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int HomePasses { get; set; }
        public int HomeAccuratePasses { get; set; }
        public int HomeCorners { get; set; }
        public int HomeFouls { get; set; }
        public int HomeOffsides { get; set; }

        
        public string AwayTeamName { get; set; }
        public string AwayTeamLogo { get; set; }
        public double AwayPossession { get; set; }
        public int AwayShots { get; set; }
        public int AwayShotsOnTarget { get; set; }
        public int AwayPasses { get; set; }
        public int AwayAccuratePasses { get; set; }
        public int AwayCorners { get; set; }
        public int AwayFouls { get; set; }
        public int AwayOffsides { get; set; }
    }
}
