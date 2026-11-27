using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Projects;

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