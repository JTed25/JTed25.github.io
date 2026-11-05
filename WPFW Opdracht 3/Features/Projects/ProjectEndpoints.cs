using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.Entities;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Projects;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints (this WebApplication app)
    {
        /*CRUD-endpoints voor Project*/
        /* GET alle projecten */
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
        
        /*GET project op id*/
        app.MapGet("/api/projects/{id}", async (int id, PortfolioDbContext db) =>
        {
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
        });
        
        /*POST project*/
        app.MapPost("/api/projects", async (
            CreateProjectDto dto, 
            PortfolioDbContext db) =>
        {
            var project = new Project
            {
                Titel = dto.Titel,
                Beschrijving = dto.Beschrijving,
                Categorie = dto.Categorie,
                GitHubUrl = dto.GitHubUrl,
                Datum = DateTime.Now
            };
            
            db.Projects.Add(project);
            await db.SaveChangesAsync();
            
            return Results.Created(
                $"/api/projects/{project.Id}",
                new ProjectDto
                {
                    Id = project.Id,
                    Titel = project.Titel,
                    Beschrijving = project.Beschrijving,
                    Categorie = project.Categorie,
                    GitHubUrl = project.GitHubUrl,
                    Datum = project.Datum
                });
        });
        
        /*PUT Project*/
        app.MapPut("/api/projects/{id}", async (
            int id,
            CreateProjectDto dto,
            PortfolioDbContext db) =>
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
        
        /*DELETE project*/
        app.MapDelete("/api/projects/{id}", async (
            int id, 
            PortfolioDbContext db) =>
        {
            var project = await db.Projects.FindAsync(id);
            
            if (project == null)
                return Results.NotFound();
            
            db.Projects.Remove(project);
        
            await db.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}