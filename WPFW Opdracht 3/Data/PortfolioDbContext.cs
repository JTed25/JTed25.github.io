using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;

namespace Backend.Data;

public class PortfolioDbContext : IdentityDbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
    : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Blogpost> Blogposts { get; set; }
}