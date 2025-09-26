using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using characterDesignAPI.Common;
using characterDesignAPI.Models;

namespace characterDesignAPI.Controllers
{
    [Route("api/character-family")]
    [ApiController]
    public class CharacterFamilyController : ControllerBase
    {
        private readonly CharacterDesignFormContext _context;

        public CharacterFamilyController(CharacterDesignFormContext context)
        {
            _context = context;
        }

        // GET: api/character-family
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterFamily>>> GetCharacterFamily()
        {
            return await _context.CharacterFamily.ToListAsync();
        }

        // GET: api/character-family/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterFamily>> GetCharacterFamily(Guid id)
        {
            var characterFamily = await _context.CharacterFamily.FindAsync(id);

            if (characterFamily == null)
            {
                return NotFound();
            }

            return characterFamily;
        }

        // PUT: api/character-family/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterFamily(Guid id, CharacterFamily characterFamily)
        {
            if (id != characterFamily.FamilyId)
            {
                return BadRequest();
            }

            _context.Entry(characterFamily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterFamilyExists(id))
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

        // POST: api/character-family
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterFamily>> PostCharacterFamily(CharacterFamily characterFamily)
        {
            _context.CharacterFamily.Add(characterFamily);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterFamily", new { id = characterFamily.FamilyId }, characterFamily);
        }

        // DELETE: api/character-family/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterFamily(Guid id)
        {
            var characterFamily = await _context.CharacterFamily.FindAsync(id);
            if (characterFamily == null)
            {
                return NotFound();
            }

            _context.CharacterFamily.Remove(characterFamily);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterFamilyExists(Guid id)
        {
            return _context.CharacterFamily.Any(e => e.FamilyId == id);
        }
    }
}
