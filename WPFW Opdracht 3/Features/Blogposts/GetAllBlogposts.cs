using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Blogposts;

public static class GetAllBlogposts
{
    public static RouteGroupBuilder MapGetAllBlogposts(this RouteGroupBuilder group)
    {
        /*GET alle blogposts*/
        group.MapGet("/", async (PortfolioDbContext db) =>
        {
            var blogposts = await db.Blogposts
                .Select(b => new BlogpostDto
                {
                    Id = b.Id,
                    Titel = b.Titel,
                    Inhoud = b.Inhoud,
                    Publicatiedatum = b.Publicatiedatum
                    })
                    .ToListAsync();
                    
                return Results.Ok(blogposts);
            })
            .AllowAnonymous();

            return group;
    }
}