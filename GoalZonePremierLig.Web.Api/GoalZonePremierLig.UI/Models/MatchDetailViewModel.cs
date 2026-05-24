using GoalZonePremierLig.UI.Dtos.MatchDto;
using GoalZonePremierLig.UI.Dtos.MatchStatisticDto;
using GoalZonePremierLig.Web.Api.Dtos.MatchDto;

namespace GoalZonePremierLig.UI.Models
{
    public class MatchDetailViewModel
    {
        public ResultDetailMatchDto Match { get; set; }

        public List<ResultMatchEventDto> Events { get; set; }

        public ResultStatisticDto Statistics { get; set; }
    }
}
