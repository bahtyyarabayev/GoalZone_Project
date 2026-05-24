using GoalZonePremierLig.UI.Dtos.FixtureDtos;
using GoalZonePremierLig.UI.Models;
using GoalZonePremierLig.UI.Services.FixtureServices;
using GoalZonePremierLig.Web.Api.Dtos.FixtureDtos;
using Microsoft.AspNetCore.Mvc;

namespace GoalZonePremierLig.UI.Controllers
{
    public class FixtureController : Controller
    {
        private readonly IFixtureService _fixtureService;

        public FixtureController(IFixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }

        public async Task<IActionResult> Index(string week = "37.Hafta")
        {
            var model = await _fixtureService.GetFixturePageAsync(week);

            ViewBag.Week = week;

            return View(model);
        }
    }
}
