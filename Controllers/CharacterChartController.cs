using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using characterDesignAPI.Common;
using characterDesignAPI.Models;

namespace characterDesignAPI.Controllers
{
    [Route("api/character")]
    [ApiController]
    public class CharacterChartController : ControllerBase
    {
        private readonly CharacterDesignFormContext _context;

        public CharacterChartController(CharacterDesignFormContext context)
        {
            _context = context;
        }

        // GET: api/character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterChart>>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        // GET: api/character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterChart>> GetCharacterChart(Guid id)
        {
            var characterChart = await _context.Characters.FindAsync(id);

            if (characterChart == null)
            {
                return NotFound();
            }

            return characterChart;
        }

        // PUT: api/character/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterChart(Guid id, CharacterChart characterChart)
        {
            if (id != characterChart.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(characterChart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterChartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/character
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterChart>> PostCharacterChart(CharacterChart characterChart)
        {
            characterChart.CharacterId = Guid.NewGuid();
            //characterChart.DateCreated = DateTime.Now;
            _context.Characters.Add(characterChart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterChart", new { id = characterChart.CharacterId }, characterChart);
        }

        // DELETE: api/character/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterChart(Guid id)
        {
            var characterChart = await _context.Characters.FindAsync(id);
            if (characterChart == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(characterChart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterChartExists(Guid id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
