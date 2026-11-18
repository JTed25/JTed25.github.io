using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Projects;

public static class DeleteProject
{
    public static RouteGroupBuilder MapDeleteProject(
        this RouteGroupBuilder group)
    {
        /*DELETE project*/
        group.MapDelete("/{id}", async (int id, PortfolioDbContext db) =>
        {
            var project = await db.Projects.FindAsync(id);

            if (project == null)
                return Results.NotFound();

            db.Projects.Remove(project);

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        return group;
    }
}