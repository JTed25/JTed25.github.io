using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Projects;

public static class GetAllProjects
{
    public static void MapGetAllProjects(this WebApplication app)
    {
        /*GET alle projecten*/
        app.MapGet("/api/projects", async (PortfolioDbContext db) =>
        {
            var projects = await db.Projects
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Titel = p.Titel,
                    Beschrijving = p.Beschrijving,
                    Categorie = p.Categorie,
                    GitHubUrl = p.GitHubUrl,
                    Datum = p.Datum
                    })
                    .ToListAsync();
                    
                return Results.Ok(projects);
            });
    }
}