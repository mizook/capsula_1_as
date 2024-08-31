using Microsoft.EntityFrameworkCore;

public class FirstDbContext : DbContext
{
    public FirstDbContext(DbContextOptions<FirstDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
