using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Entities;

namespace WPFW_Opdracht_3.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
    : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Blogpost> Blogposts { get; set; }
}