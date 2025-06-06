using characterDesignAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Produces("application/json")]
[Route("api/get-characters")]
public class CharacterController : ControllerBase
{
    private readonly CharacterDesignFormContext _context;
    public CharacterController(CharacterDesignFormContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<CharacterChart>> Get() => await _context.CharacterChart.ToListAsync();
}