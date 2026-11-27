using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;
using Backend.Entities;

namespace Backend.Features.Blogposts;

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