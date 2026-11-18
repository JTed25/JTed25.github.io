using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Projects;

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