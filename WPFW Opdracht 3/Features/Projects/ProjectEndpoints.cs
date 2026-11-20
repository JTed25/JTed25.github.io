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
        var group = app.MapGroup("/api/projects");

        group.MapGetAllProjects();
        group.MapGetProjectById();
        group.MapPostProject().RequireAuthorization("EditorOrAdmin");
        group.MapPutProject().RequireAuthorization("EditorOrAdmin");
        group.MapDeleteProject().RequireAuthorization("EditorOrAdmin");
    }
}