using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using GoalZonePremierLig.Web.Api.Dtos.TeamsDto;
using GoalZonePremierLig.Web.Api.Dtos.FixtureDtos;
using GoalZonePremierLig.Web.Api.Dtos.MatchStatisticDto;
using GoalZonePremierLig.UI.Dtos.MatchStatisticDto;

namespace GoalZonePremierLig.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _http;

        public AdminController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
            _http.BaseAddress = new Uri("https://localhost:7212/");
        }

        public async Task<IActionResult> AddMatch()
        {
            var teams = await _http.GetFromJsonAsync<List<ResultTeamDto>>("api/Fixture/GetTeams");
            ViewBag.Teams = teams ?? new List<ResultTeamDto>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMatch(CreateFixtureDto dto)
        {
            var payload = new
            {
                homeTeamId = dto.HomeTeamId,
                awayTeamId = dto.AwayTeamId,
                homeScore = dto.HasScore ? dto.HomeScore : (int?)null,
                awayScore = dto.HasScore ? dto.AwayScore : (int?)null,
                matchDate = dto.MatchDate,
                stadium = dto.Stadium,
                week = dto.Week,
                status = dto.Status,
                minute = dto.Minute,
                isFeatured = dto.IsFeatured
            };

            var response = await _http.PostAsJsonAsync("api/Fixture/Create", payload);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Maç başarıyla eklendi!";
                return RedirectToAction("AddMatch");
            }

            TempData["Error"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            var teams = await _http.GetFromJsonAsync<List<ResultTeamDto>>("api/Fixture/GetTeams");
            ViewBag.Teams = teams ?? new List<ResultTeamDto>();
            return View(dto);
        }

        public async Task<IActionResult> AddStatistic()
        {
            var fixtures = await _http.GetFromJsonAsync<List<ResultFixtureDto>>("api/MatchStatistic/GetFixtures");
            ViewBag.Fixtures = fixtures ?? new List<ResultFixtureDto>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStatistic(CreateStatisticFormDto dto)
        {
            var homePayload = new CreateStatisticDto
            {
                MatchId = dto.MatchId,
                TeamId = dto.HomeTeamId,
                BallPossession = dto.HomePossession,
                Shots = dto.HomeShots,
                ShotsOnTarget = dto.HomeShotsOnTarget,
                Passes = dto.HomePasses,
                AccuratePasses = dto.HomeAccuratePasses,
                Corners = dto.HomeCorners,
                Fouls = dto.HomeFouls,
                Offsides = dto.HomeOffsides
            };

            var awayPayload = new CreateStatisticDto
            {
                MatchId = dto.MatchId,
                TeamId = dto.AwayTeamId,
                BallPossession = dto.AwayPossession,
                Shots = dto.AwayShots,
                ShotsOnTarget = dto.AwayShotsOnTarget,
                Passes = dto.AwayPasses,
                AccuratePasses = dto.AwayAccuratePasses,
                Corners = dto.AwayCorners,
                Fouls = dto.AwayFouls,
                Offsides = dto.AwayOffsides
            };

            var r1 = await _http.PostAsJsonAsync("api/MatchStatistic/Create", homePayload);
            var r2 = await _http.PostAsJsonAsync("api/MatchStatistic/Create", awayPayload);

            if (r1.IsSuccessStatusCode && r2.IsSuccessStatusCode)
            {
                TempData["Success"] = "İstatistikler başarıyla eklendi!";
                return RedirectToAction("AddStatistic");
            }

            TempData["Error"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            var fixtures = await _http.GetFromJsonAsync<List<ResultFixtureDto>>("api/MatchStatistic/GetFixtures");
            ViewBag.Fixtures = fixtures ?? new List<ResultFixtureDto>();
            return View(dto);
        }
    }
}