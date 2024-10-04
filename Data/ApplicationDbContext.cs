using Microsoft.EntityFrameworkCore;

namespace RepasoJWT.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}
