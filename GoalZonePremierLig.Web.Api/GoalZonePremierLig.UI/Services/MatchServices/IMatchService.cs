using GoalZonePremierLig.UI.Models;
using GoalZonePremierLig.Web.Api.Dtos.MatchDto;

namespace GoalZonePremierLig.UI.Services.MatchServices
{
    public interface IMatchService
    {
        Task<List<ResultMatchDto>> GetMatchesAsync();
        Task<MatchDetailViewModel?> GetMatchDetailAsync(int id);
    }
}
