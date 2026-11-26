using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Projects;

public static class GetProjectById
{
    public static RouteGroupBuilder MapGetProjectById(
        this RouteGroupBuilder group)
    {
        /*GET project op id*/
        group.MapGet("/{id}", async (int id, PortfolioDbContext db) =>
        {
            Console.WriteLine($"GET PROJECT ID: {id}");
            
            var project = await db.Projects.FindAsync(id);
            
            if (project == null)
                return Results.NotFound();

            return Results.Ok(new ProjectDto
                {
                    Id = project.Id,
                    Titel = project.Titel,
                    Beschrijving = project.Beschrijving,
                    Categorie = project.Categorie,
                    GitHubUrl = project.GitHubUrl,
                    Datum = project.Datum
                });
            })
            .AllowAnonymous();
        
        return group;
    }
}