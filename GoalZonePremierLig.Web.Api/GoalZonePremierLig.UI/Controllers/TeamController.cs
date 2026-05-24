using GoalZonePremierLig.UI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace GoalZonePremierLig.UI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> TeamList()
        {
            var values = await _teamService.GetStandingsAsync();
            return View(values);
        }
    }
}
