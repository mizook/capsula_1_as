using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PostgresDb1Controller : ControllerBase
{
    private readonly FirstDbContext _context1;

    public PostgresDb1Controller(FirstDbContext context1)
    {
        _context1 = context1;
        InitializeDB();
    }

    private void InitializeDB()
    {
        _context1.Database.EnsureCreated();

        if (!_context1.Users.Any())
        {
            _context1.Users.AddRange(
                new User { Name = "Usuario 1" }
            );
            _context1.SaveChanges();
        }
    }

    // POST: /PostgresDb1/users
    [HttpPost("users")]
    public IActionResult Post([FromBody] User newUser)
    {
        _context1.Users.Add(newUser);
        _context1.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    // GET: /PostgresDb1/users
    [HttpGet("users")]
    public IActionResult Get()
    {
        var data = _context1.Users.ToList();

        return Ok(new { data });
    }
}
