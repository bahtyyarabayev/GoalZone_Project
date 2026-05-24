using GoalZonePremierLig.UI.Dtos.MatchStatisticDto;

namespace GoalZonePremierLig.UI.Services.StatisticService
{
    public interface IStatisticService
    {
        Task<ResultStatisticDto?> GetByFixtureAsync(int fixtureId);
    }
}
