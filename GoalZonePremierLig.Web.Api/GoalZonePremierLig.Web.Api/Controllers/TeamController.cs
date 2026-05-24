using AutoMapper;
using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.TeamsDto;
using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly GoalZoneContext _context;
        private readonly IMapper _mapper;

        public TeamController(GoalZoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private IQueryable<Team> BaseQuery()
        {
            return _context.Teams.AsNoTracking();
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            var values = BaseQuery().ToList();
            return Ok(_mapper.Map<List<ResultTeamDto>>(values));
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            var value = BaseQuery()
                .FirstOrDefault(x => x.TeamId == id);

            if (value == null)
                return NotFound("Takım bulunamadı");

            return Ok(_mapper.Map<GetByIdTeamDto>(value));
        }

        [HttpGet("top")]
        public IActionResult GetTopTeams()
        {
            var values = BaseQuery()
                .Take(5)
                .ToList();

            return Ok(_mapper.Map<List<ResultTeamDto>>(values));
        }

        [HttpGet("count")]
        public IActionResult GetTeamCount()
        {
            var count = _context.Teams.Count();
            return Ok(count);
        }
    }
}

