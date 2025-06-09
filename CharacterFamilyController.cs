using characterDesignAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Produces("application/json")]
[Route("api/get-families")]

public class CharacterFamilyController : ControllerBase
{
    private readonly CharacterDesignFormContext _context;
    public CharacterFamilyController(CharacterDesignFormContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<CharacterFamily>> GetFamilies() => await _context.Families.ToListAsync();
}