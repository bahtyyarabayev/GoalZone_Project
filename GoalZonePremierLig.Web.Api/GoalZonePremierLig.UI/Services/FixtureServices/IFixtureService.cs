using GoalZonePremierLig.UI.Models;

namespace GoalZonePremierLig.UI.Services.FixtureServices
{
    public interface IFixtureService
    {
        Task<FixtureModel> GetFixturePageAsync(string week);
    }
}
