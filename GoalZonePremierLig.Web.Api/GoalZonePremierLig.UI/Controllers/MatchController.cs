using GoalZonePremierLig.UI.Services.MatchServices;
using Microsoft.AspNetCore.Mvc;

namespace GoalZonePremierLig.UI.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public async Task<IActionResult> MatchList()
        {
            var values = await _matchService.GetMatchesAsync();
            return View(values);
        }

        public async Task<IActionResult> MatchDetail(int id)
        {
            var model = await _matchService.GetMatchDetailAsync(id);

            if (model == null || model.Match == null)
                return NotFound();

            return View(model);
        }
    }
}
