using GoalZonePremierLig.Web.Api.Dtos.StandingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZonePremierLig.UI.Services.TeamServices
{
    public interface ITeamService
    {
        Task<List<ResultStandingDto>> GetStandingsAsync();
    }
}