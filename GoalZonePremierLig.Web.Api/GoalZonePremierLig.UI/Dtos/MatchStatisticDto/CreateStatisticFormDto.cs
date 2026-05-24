namespace GoalZonePremierLig.UI.Dtos.MatchStatisticDto
{
    public class CreateStatisticFormDto
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public double HomePossession { get; set; }
        public int HomeShots { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int HomePasses { get; set; }
        public int HomeAccuratePasses { get; set; }
        public int HomeCorners { get; set; }
        public int HomeFouls { get; set; }
        public int HomeOffsides { get; set; }
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
