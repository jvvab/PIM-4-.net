using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PIM_4_SEMESTRE.MinhaAplicacao.Data;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return Ok(new { message = "Usuário registrado com sucesso!" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
        
        if (user == null)
            return Unauthorized(new { message = "Email ou senha inválidos!" });
        
        return Ok(new { message = "Login realizado com sucesso!" });
    }
}

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}