using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Projects;

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