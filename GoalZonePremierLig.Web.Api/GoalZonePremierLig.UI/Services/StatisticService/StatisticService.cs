using GoalZonePremierLig.UI.Dtos.MatchStatisticDto;

namespace GoalZonePremierLig.UI.Services.StatisticService
{
    public class StatisticService:IStatisticService
    {
        private readonly HttpClient _http;

        public StatisticService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://localhost:7212/");
        }

        public async Task<ResultStatisticDto?> GetByFixtureAsync(int fixtureId)
        {
            return await _http.GetFromJsonAsync<ResultStatisticDto>
                ($"api/MatchStatistic/GetByFixture/{fixtureId}");
        }
    }
}
