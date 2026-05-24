using AutoMapper;
using GoalZonePremierLig.Web.Api.Context;
using GoalZonePremierLig.Web.Api.Dtos.MatchDto;
using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZonePremierLig.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly GoalZoneContext _context;
        private readonly IMapper _mapper;

        public MatchController(GoalZoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        private IQueryable<Fixture> BaseQuery()
        {
            return _context.Fixtures
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam);
        }

        [HttpGet]
        public IActionResult MatchList()
        {
            var values = BaseQuery().ToList();
            return Ok(_mapper.Map<List<ResultMatchDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMatch(CreateMatchDto dto)
        {
            var entity = _mapper.Map<Fixture>(dto);
            _context.Fixtures.Add(entity);
            _context.SaveChanges();

            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMatch(int id)
        {
            var entity = _context.Fixtures.Find(id);

            if (entity == null)
                return NotFound();

            _context.Fixtures.Remove(entity);
            _context.SaveChanges();

            return Ok("Silme İşlemi Başarılı");
        }


        [HttpGet("{id}")]
        public IActionResult GetMatch(int id)
        {
            var value = BaseQuery()
                .FirstOrDefault(x => x.FixtureId == id);

            if (value == null)
                return NotFound();

            return Ok(_mapper.Map<GetByIdMatchDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateMatch(UpdateMatchDto dto)
        {
            var entity = _mapper.Map<Fixture>(dto);
            _context.Fixtures.Update(entity);
            _context.SaveChanges();

            return Ok("Güncelleme İşlemi Başarılı");
        }


        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(string status)
        {
            var values = BaseQuery()
                .Where(x => x.Status == status)
                .ToList();

            return Ok(_mapper.Map<List<ResultMatchDto>>(values));
        }


        [HttpGet("featured")]
        public IActionResult FeaturedMatches()
        {
            var values = BaseQuery()
                .Where(x => x.IsFeatured)
                .ToList();

            return Ok(_mapper.Map<List<ResultMatchDto>>(values));
        }

 
        [HttpGet("count/{status}")]
        public IActionResult CountByStatus(string status)
        {
            var count = _context.Fixtures.Count(x => x.Status == status);
            return Ok(count);
        }


        [HttpGet("detail/{id}")]
        public IActionResult GetMatchDetail(int id)
        {
            var value = BaseQuery()
                .FirstOrDefault(x => x.FixtureId == id);

            if (value == null)
                return NotFound();

            return Ok(_mapper.Map<ResultDetailMatchDto>(value));
        }
    }
}
