using GoalZonePremierLig.UI.Dtos.FixtureDtos;
using GoalZonePremierLig.UI.Models;
using GoalZonePremierLig.Web.Api.Dtos.FixtureDtos;

namespace GoalZonePremierLig.UI.Services.FixtureServices
{
    public class FixtureService:IFixtureService
    {
        private readonly HttpClient _http;

        public FixtureService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://localhost:7212/");
        }

        public async Task<FixtureModel> GetFixturePageAsync(string week)
        {
            var model = new FixtureModel();

            var encodedWeek = Uri.EscapeDataString(week);

            var fixturesTask = _http.GetFromJsonAsync<List<ResultFixtureDto>>
                ($"api/Fixture/GetByWeek?week={encodedWeek}");

            var liveTask = _http.GetFromJsonAsync<List<ResultFixtureLiveDto>>
                ("api/Fixture/GetLiveMatches");

            var featuredTask = _http.GetFromJsonAsync<List<FeaturedDto>>
                ("api/Fixture/GetFeaturedMatches");

            var summaryTask = _http.GetFromJsonAsync<FixtureStatsDto>
                ($"api/Fixture/GetWeekSummary?week={encodedWeek}");

            await Task.WhenAll(fixturesTask, liveTask, featuredTask, summaryTask);

            model.Fixtures = fixturesTask.Result ?? new();
            model.LiveMatches = liveTask.Result ?? new();
            model.FeaturedMatches = featuredTask.Result ?? new();
            model.Summary = summaryTask.Result;

            return model;
        }
    }
}
