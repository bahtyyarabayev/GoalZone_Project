using AutoMapper;
using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.MatchEventsDto;
using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly GoalZoneContext _context;
        private readonly IMapper _mapper;

        public MatchEventController(GoalZoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<MatchEvents> BaseQuery()
        {
            return _context.MatchEvents
                .Include(x => x.Team)
                .Include(x => x.Player)
                .Include(x => x.Fixture);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = BaseQuery().ToList();
            return Ok(_mapper.Map<List<ResultEventsDto>>(values));
        }

        [HttpGet("by-match/{matchId}")]
        public IActionResult GetByMatchId(int matchId)
        {
            var values = BaseQuery()
                .Where(x => x.FixtureId == matchId)
                .OrderBy(x => x.Minute)
                .ToList();

            return Ok(_mapper.Map<List<ResultEventsDto>>(values));
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = BaseQuery()
                .FirstOrDefault(x => x.MatchEventId == id);

            if (value == null)
                return NotFound("Kayıt bulunamadı.");

            return Ok(_mapper.Map<GetByIdMatchEventsDto>(value));
        }
 
        [HttpGet("dashboard-summary")]
        public IActionResult GetDashboardSummary()
        {
            var matches = _context.Fixtures.AsNoTracking();
            var teams = _context.Teams.AsNoTracking();
            var players = _context.Players.AsNoTracking();

            var result = new
            {
                TotalMatch = matches.Count(),
                LiveMatch = matches.Count(x => x.Status == "Live"),
                FinishedMatch = matches.Count(x => x.Status == "Finished"),
                UpcomingMatch = matches.Count(x => x.Status == "Upcoming"),

                TotalTeam = teams.Count(),
                TotalPlayer = players.Count(),

                FeaturedMatch = matches
                    .Where(x => x.IsFeatured)
                    .Include(x => x.HomeTeam)
                    .Include(x => x.AwayTeam)
                    .Select(x => new
                    {
                        x.FixtureId,
                        x.HomeScore,
                        x.AwayScore,
                        x.Status,
                        x.Minute,
                        x.Week,
                        HomeTeam = x.HomeTeam.Name,
                        HomeLogoUrl = x.HomeTeam.LogoUrl,
                        AwayTeam = x.AwayTeam.Name,
                        AwayLogoUrl = x.AwayTeam.LogoUrl
                    })
                    .ToList(),

                RecentMatches = matches
                    .Include(x => x.HomeTeam)
                    .Include(x => x.AwayTeam)
                    .OrderByDescending(x => x.MatchDate)
                    .Take(5)
                    .Select(x => new
                    {
                        x.FixtureId,
                        x.HomeScore,
                        x.AwayScore,
                        x.Status,
                        x.Minute,
                        x.MatchDate,
                        HomeTeam = x.HomeTeam.Name,
                        HomeLogoUrl = x.HomeTeam.LogoUrl,
                        AwayTeam = x.AwayTeam.Name,
                        AwayLogoUrl = x.AwayTeam.LogoUrl
                    })
                    .ToList(),

                TopScorers = players
                    .Include(x => x.Team)
                    .Where(x => x.Goals > 0)
                    .OrderByDescending(x => x.Goals)
                    .Take(5)
                    .Select(x => new
                    {
                        x.PlayerId,
                        x.NameSurname,
                        x.Goals,
                        x.KeyPasses,
                        x.ImageUrl,
                        TeamName = x.Team.Name
                    })
                    .ToList()
            };

            return Ok(result);
        }
    }
}
