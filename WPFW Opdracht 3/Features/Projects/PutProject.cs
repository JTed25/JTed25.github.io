using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Projects;

public static class PutProject
{
    public static RouteGroupBuilder MapPutProject(
        this RouteGroupBuilder group)
    {
        /*PUT project*/
        group.MapPut("/{id}", async (int id, CreateProjectDto dto, PortfolioDbContext db) =>
        {
            var project = await db.Projects.FindAsync(id);
            
            if (project == null)
                return Results.NotFound();

            project.Titel = dto.Titel;
            project.Beschrijving = dto.Beschrijving;
            project.Categorie = dto.Categorie;
            project.GitHubUrl = dto.GitHubUrl;
            
            await db.SaveChangesAsync();

            return Results.Ok();
        });

        return group;
    }
}