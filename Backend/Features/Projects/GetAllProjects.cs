using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Projects;

public static class GetAllProjects
{
    public static RouteGroupBuilder MapGetAllProjects(this RouteGroupBuilder group)
    {
        /*GET alle projecten*/
        group.MapGet("/", async (PortfolioDbContext db) =>
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
            })
            .AllowAnonymous();

            return group;
    }
}