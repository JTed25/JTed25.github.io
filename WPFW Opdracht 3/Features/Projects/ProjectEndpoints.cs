using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Entities;
using Backend.DTOs;

namespace Backend.Features.Projects;

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