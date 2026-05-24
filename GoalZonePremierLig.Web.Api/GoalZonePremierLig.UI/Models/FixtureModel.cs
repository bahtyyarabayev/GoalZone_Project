using GoalZonePremierLig.UI.Dtos.FixtureDtos;
using GoalZonePremierLig.Web.Api.Dtos.FixtureDtos;

namespace GoalZonePremierLig.UI.Models
{
    public class FixtureModel
    {
        public List<ResultFixtureDto> Fixtures { get; set; }

        public List<ResultFixtureLiveDto> LiveMatches { get; set; }

        public List<FeaturedDto> FeaturedMatches { get; set; }

        public FixtureStatsDto Summary { get; set; }
    }
}
