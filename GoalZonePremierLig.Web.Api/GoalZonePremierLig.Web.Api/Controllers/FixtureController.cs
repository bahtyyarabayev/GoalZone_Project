using AutoMapper;
using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.FixtureDtos;
using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly GoalZoneContext _context;
        private readonly IMapper _mapper;

        public FixtureController(GoalZoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
   
        private IQueryable<Fixture> BaseMatchQuery()
        {
            return _context.Fixtures
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .AsNoTracking();
        }
      
        [HttpGet]
        public IActionResult FixtureList()
        {
            var result = BaseMatchQuery()
                .OrderBy(m => m.MatchDate)
                .ToList();

            return Ok(_mapper.Map<List<ResultFixtureDto>>(result));
        }

        [HttpGet("GetByWeek")]
        public IActionResult GetByWeek(string week)
        {
            var result = BaseMatchQuery()
                .Where(m => m.Week == week)
                .OrderBy(m => m.MatchDate)
                .ToList();

            return Ok(_mapper.Map<List<ResultFixtureDto>>(result));
        }
        [HttpGet("GetLiveMatches")]
        public IActionResult GetLiveMatches()
        {
            var result = BaseMatchQuery()
                .Where(m => m.Status == "Live")
                .OrderBy(m => m.MatchDate)
                .ToList();

            return Ok(_mapper.Map<List<ResultFixtureLiveDto>>(result));
        }

        [HttpGet("GetFeaturedMatches")]
        public IActionResult GetFeaturedMatches()
        {
            var result = BaseMatchQuery()
                .Where(m => m.IsFeatured)
                .OrderByDescending(m => m.MatchDate)
                .ToList();

            return Ok(_mapper.Map<List<FeaturedDto>>(result));
        }

        [HttpGet("GetWeekSummary")]
        public IActionResult GetWeekSummary(string week)
        {
            var matches = _context.Fixtures
                .AsNoTracking()
                .Where(m => m.Week == week)
                .ToList();
            var summary = new ResultWeekDto
            {
                Week = week,
                TotalMatch = matches.Count,
                LiveMatch = matches.Count(x => x.Status == "Live"),
                FinishedMatch = matches.Count(x => x.Status == "Finished"),
                UpcomingMatch = matches.Count(x => x.Status == "Upcoming"),
                FeaturedMatch = matches.Count(x => x.IsFeatured)
            };

            return Ok(summary);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateFixtureDto dto)
        {
            if (dto.HomeTeamId == dto.AwayTeamId)
                return BadRequest("Ev sahibi ve deplasman takımı aynı olamaz.");

            var fixture = new Fixture
            {
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId,
                HomeScore = dto.HomeScore,
                AwayScore = dto.AwayScore,
                MatchDate = dto.MatchDate,
                Stadium = dto.Stadium,
                Week = dto.Week,
                Status = dto.Status,
                Minute = dto.Minute,
                IsFeatured = dto.IsFeatured
            };

            _context.Fixtures.Add(fixture);
            _context.SaveChanges();

            return Ok(new { message = "Maç başarıyla eklendi.", fixtureId = fixture.FixtureId });
        }

        [HttpGet("GetTeams")]
        public IActionResult GetTeams()
        {
            var teams = _context.Teams
                .AsNoTracking()
                .Where(t => t.IsActive)
                .OrderBy(t => t.Name)
                .Select(t => new { t.TeamId, t.Name, t.ShortName, t.LogoUrl })
                .ToList();

            return Ok(teams);
        }
    }
}

