namespace GoalZonePremierLig.Web.Api.Dtos.FixtureDtos
{
    public class ResultWeekDto
    {
        public string Week { get; set; }

        public int TotalMatch { get; set; }

        public int LiveMatch { get; set; }

        public int FinishedMatch { get; set; }

        public int UpcomingMatch { get; set; }

        public int FeaturedMatch { get; set; }
    }
}
