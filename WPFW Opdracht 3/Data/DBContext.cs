using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Entities;

namespace WPFW_Opdracht_3.Data;

public class PfDBContext : Context
{
    public PfDBContext(DbContextOptions<PfDBContext> options)
    : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Blogpost> Blogposts => Set<Blogpost>();
}
