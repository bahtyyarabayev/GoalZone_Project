namespace GoalZonePremierLig.Web.Api.Dtos.MatchStatisticDto
{
    public class CreateStatisticDto
    {
        public int FixtureId { get; set; }
        public int TeamId { get; set; }
        public double BallPossession { get; set; }
        public int Shots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int Passes { get; set; }
        public int AccuratePasses { get; set; }
        public int Corners { get; set; }
        public int Fouls { get; set; }
        public int Offsides { get; set; }
    }
}
