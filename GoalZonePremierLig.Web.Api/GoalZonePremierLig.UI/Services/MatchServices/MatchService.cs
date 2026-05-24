using GoalZonePremierLig.UI.Dtos.MatchDto;
using GoalZonePremierLig.UI.Dtos.MatchStatisticDto;
using GoalZonePremierLig.UI.Models;
using GoalZonePremierLig.UI.Services.MatchServices;
using GoalZonePremierLig.Web.Api.Dtos.MatchDto;

public class MatchService : IMatchService
{
    private readonly HttpClient _client;

    public MatchService(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://localhost:7212/");
    }

    public async Task<List<ResultMatchDto>> GetMatchesAsync()
    {
        return await _client.GetFromJsonAsync<List<ResultMatchDto>>
            ("api/Match") ?? new();
    }

    public async Task<MatchDetailViewModel?> GetMatchDetailAsync(int id)
    {
        var matchTask = _client.GetFromJsonAsync<ResultDetailMatchDto>
            ($"api/Match/detail/{id}");

        var eventTask = _client.GetFromJsonAsync<List<ResultMatchEventDto>>
            ($"api/MatchEvent/by-match/{id}");

        await Task.WhenAll(matchTask, eventTask);

        ResultStatisticDto? stats = null;
        try
        {
            stats = await _client.GetFromJsonAsync<ResultStatisticDto>
                ($"api/MatchStatistic/GetByFixture/{id}");
        }
        catch { }

        return new MatchDetailViewModel
        {
            Match = await matchTask,
            Events = await eventTask ?? new(),
            Statistics = stats
        };
    }
}