using Microsoft.EntityFrameworkCore;
using RepasoJWT.Models;

namespace RepasoJWT.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}
