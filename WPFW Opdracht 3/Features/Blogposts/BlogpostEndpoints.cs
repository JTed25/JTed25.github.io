using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.Entities;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Blogposts;
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