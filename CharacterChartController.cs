using characterDesignAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Produces("application/json")]
[Route("api/get-characters")]
public class CharacterChartController : ControllerBase
{
    private readonly CharacterDesignFormContext _context;
    public CharacterChartController(CharacterDesignFormContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<CharacterChart>> GetCharacters() => await _context.Characters.ToListAsync();
}