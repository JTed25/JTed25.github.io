using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;
using WPFW_Opdracht_3.Entities;

namespace WPFW_Opdracht_3.Features.Blogposts;

public static class PostBlogpost
{
    public static RouteGroupBuilder MapPostBlogpost(
        this RouteGroupBuilder group)
    {
        /*POST Blogpost*/
        group.MapPost("/", async (CreateBlogpostDto dto, PortfolioDbContext db) =>
        {
            var blogpost = new Blogpost
            {
                Titel = dto.Titel,
                Inhoud = dto.Inhoud,
                Publicatiedatum = DateTime.Now
            };

            db.Blogposts.Add(blogpost);
            await db.SaveChangesAsync();

            return Results.Created(
                $"/api/blogpost/{blogpost.Id}",
                new BlogpostDto
                {
                    Id = blogpost.Id,
                    Titel = blogpost.Titel,
                    Inhoud = blogpost.Inhoud,
                    Publicatiedatum = blogpost.Publicatiedatum
                });
        });

        return group;
    }
}