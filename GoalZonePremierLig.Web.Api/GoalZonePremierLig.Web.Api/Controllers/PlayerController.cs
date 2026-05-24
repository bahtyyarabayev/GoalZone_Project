using AutoMapper;
using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.PlayersDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly GoalZoneContext _context;
        private readonly IMapper _mapper;

        public PlayerController(GoalZoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult PlayerList()
        {
            var values = _context.Players.Include(x => x.Team).ToList();
            return Ok(_mapper.Map<List<ResultPlayerDto>>(values));
        }
    }
}
