using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Blogposts;

public static class GetBlogpostById
{
    public static RouteGroupBuilder MapGetBlogpostById(
        this RouteGroupBuilder group)
    {
        /*GET blogpost op id*/
        group.MapGet("/{id}", async (int id, PortfolioDbContext db) =>
        {
            Console.WriteLine($"GET BLOGPOST ID: {id}");

            var blogpost = await db.Blogposts.FindAsync(id);
            
            if (blogpost == null)
                return Results.NotFound();

            return Results.Ok(new BlogpostDto
                {
                    Id = blogpost.Id,
                    Titel = blogpost.Titel,
                    Inhoud = blogpost.Inhoud,
                    Publicatiedatum = blogpost.Publicatiedatum
                });
            })
            .AllowAnonymous();
        
        return group;
    }
}