using AutoMapper;
using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.StandingDto;
using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly GoalZoneContext _context;
        private readonly IMapper _mapper;

        public StandingController(GoalZoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private IQueryable<Standing> BaseQuery()
        {
            return _context.Standings
                .Include(x => x.Team);
        }

     
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = BaseQuery()
                .OrderBy(x => x.Position)
                .ToList();

            return Ok(_mapper.Map<List<ResultStandingDto>>(values));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = BaseQuery()
                .FirstOrDefault(x => x.StandingId == id);

            if (value == null)
                return NotFound("Kayıt bulunamadı");

            return Ok(_mapper.Map<GetByIdStandingDto>(value));
        }
       
        [HttpGet("top")]
        public IActionResult GetTopTeams()
        {
            var values = BaseQuery()
                .OrderBy(x => x.Position)
                .Take(5)
                .ToList();

            return Ok(_mapper.Map<List<ResultStandingDto>>(values));
        }
     
        [HttpGet("relegation")]
        public IActionResult GetRelegationZone()
        {
            var values = BaseQuery()
                .OrderByDescending(x => x.Position)
                .Take(3)
                .ToList();

            return Ok(_mapper.Map<List<ResultStandingDto>>(values));
        }
    }
}

