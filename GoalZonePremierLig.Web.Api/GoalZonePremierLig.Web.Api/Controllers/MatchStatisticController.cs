using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.MatchStatisticDto;
using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticController : ControllerBase
    {
        private readonly GoalZoneContext _context;

        public MatchStatisticController(GoalZoneContext context)
        {
            _context = context;
        }

        [HttpGet("GetByFixture/{fixtureId}")]
        public IActionResult GetByFixture(int fixtureId)
        {
            var stats = _context.Statistics
                .Include(s => s.Team)
                .Include(s => s.Fixture)
                    .ThenInclude(f => f.HomeTeam)
                .Include(s => s.Fixture)
                    .ThenInclude(f => f.AwayTeam)
                .AsNoTracking()
                .Where(s => s.FixtureId == fixtureId)
                .ToList();

            if (!stats.Any())
                return Ok(new ResultStatisticDto());

            var fixture = stats.First().Fixture;
            var home = stats.FirstOrDefault(s => s.TeamId == fixture.HomeTeamId);
            var away = stats.FirstOrDefault(s => s.TeamId == fixture.AwayTeamId);

            var dto = new ResultStatisticDto
            {
                HomeTeamName = fixture.HomeTeam?.Name ?? "",
                HomeTeamLogo = fixture.HomeTeam?.LogoUrl ?? "",
                HomePossession = home?.BallPossession ?? 0,
                HomeShots = home?.Shots ?? 0,
                HomeShotsOnTarget = home?.ShotsOnTarget ?? 0,
                HomePasses = home?.Passes ?? 0,
                HomeAccuratePasses = home?.AccuratePasses ?? 0,
                HomeCorners = home?.Corners ?? 0,
                HomeFouls = home?.Fouls ?? 0,
                HomeOffsides = home?.Offsides ?? 0,

                AwayTeamName = fixture.AwayTeam?.Name ?? "",
                AwayTeamLogo = fixture.AwayTeam?.LogoUrl ?? "",
                AwayPossession = away?.BallPossession ?? 0,
                AwayShots = away?.Shots ?? 0,
                AwayShotsOnTarget = away?.ShotsOnTarget ?? 0,
                AwayPasses = away?.Passes ?? 0,
                AwayAccuratePasses = away?.AccuratePasses ?? 0,
                AwayCorners = away?.Corners ?? 0,
                AwayFouls = away?.Fouls ?? 0,
                AwayOffsides = away?.Offsides ?? 0,
            };

            return Ok(dto);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateStatisticDto dto)
        {
            
            var existing = _context.Statistics
                .FirstOrDefault(s => s.FixtureId == dto.FixtureId && s.TeamId == dto.TeamId);

            if (existing != null)
            {
                existing.BallPossession = dto.BallPossession;
                existing.Shots = dto.Shots;
                existing.ShotsOnTarget = dto.ShotsOnTarget;
                existing.Passes = dto.Passes;
                existing.AccuratePasses = dto.AccuratePasses;
                existing.Corners = dto.Corners;
                existing.Fouls = dto.Fouls;
                existing.Offsides = dto.Offsides;
                _context.SaveChanges();
                return Ok(new { message = "İstatistik güncellendi." });
            }

            var stat = new Statistics
            {
                FixtureId = dto.FixtureId,
                TeamId = dto.TeamId,
                BallPossession = dto.BallPossession,
                Shots = dto.Shots,
                ShotsOnTarget = dto.ShotsOnTarget,
                Passes = dto.Passes,
                AccuratePasses = dto.AccuratePasses,
                Corners = dto.Corners,
                Fouls = dto.Fouls,
                Offsides = dto.Offsides
            };

            _context.Statistics.Add(stat);
            _context.SaveChanges();

            return Ok(new { message = "İstatistik başarıyla eklendi." });
        }

        [HttpGet("GetFixtures")]
        public IActionResult GetFixtures()
        {
            var fixtures = _context.Fixtures
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .AsNoTracking()
                .OrderByDescending(f => f.MatchDate)
                .Select(f => new
                {
                    f.FixtureId,
                    f.Week,
                    HomeTeam = f.HomeTeam.Name,
                    AwayTeam = f.AwayTeam.Name,
                    f.HomeTeamId,
                    f.AwayTeamId,
                    f.MatchDate
                })
                .ToList();

            return Ok(fixtures);
        }
    }
}
