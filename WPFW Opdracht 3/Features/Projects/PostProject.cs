using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;
using WPFW_Opdracht_3.Entities;

namespace WPFW_Opdracht_3.Features.Projects;

public static class PostProject
{
    public static RouteGroupBuilder MapPostProject(
        this RouteGroupBuilder group)
    {
        /*POST Project*/
        group.MapPost("/", async (CreateProjectDto dto, PortfolioDbContext db) =>
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

        return group;
    }
}