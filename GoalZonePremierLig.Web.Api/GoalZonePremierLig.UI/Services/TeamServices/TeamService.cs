using System.Net.Http.Json;
using GoalZonePremierLig.UI.Services.TeamServices;
using GoalZonePremierLig.Web.Api.Dtos.StandingDto;

public class TeamService : ITeamService
{
    private readonly HttpClient _http;

    public TeamService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://localhost:7212/");
    }

    public async Task<List<ResultStandingDto>> GetStandingsAsync()
    {
        var result = await _http.GetFromJsonAsync<List<ResultStandingDto>>
            ("api/Standing");

        return result ?? new();
    }
}