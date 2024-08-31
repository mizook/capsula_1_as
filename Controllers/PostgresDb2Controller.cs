using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PostgresDb2Controller : ControllerBase
{
    private readonly SecondDbContext _context2;

    public PostgresDb2Controller(SecondDbContext context2)
    {
        _context2 = context2;
        InitializeDB();
    }

    private void InitializeDB()
    {
        _context2.Database.EnsureCreated();

        if (!_context2.Users.Any())
        {
            _context2.Users.AddRange(
                new User { Name = "Usuario 2" }
            );
            _context2.SaveChanges();
        }
    }

    // POST: /PostgresDb2/users
    [HttpPost("users")]
    public IActionResult Post([FromBody] User newUser)
    {
        _context2.Users.Add(newUser);
        _context2.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    // GET: /PostgresDb2/users
    [HttpGet("users")]
    public IActionResult Get()
    {
        var data = _context2.Users.ToList();

        return Ok(new { data });
    }
}
