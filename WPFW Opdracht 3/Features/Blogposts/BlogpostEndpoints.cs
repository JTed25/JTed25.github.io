using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Entities;
using Backend.DTOs;

namespace Backend.Features.Blogposts;
public static class BlogpostEndpoints
{
    public static void MapBlogpostEndpoints (this WebApplication app)
    {
        /*CRUD-endpoints voor Blogpost*/
        var group = app.MapGroup("/api/blogposts");

        group.MapGetAllBlogposts();
        group.MapGetBlogpostById();
        group.MapPostBlogpost().RequireAuthorization("EditorOrAdmin");
        group.MapPutBlogpost().RequireAuthorization("EditorOrAdmin");
        group.MapDeleteBlogpost().RequireAuthorization("EditorOrAdmin");
    }
}