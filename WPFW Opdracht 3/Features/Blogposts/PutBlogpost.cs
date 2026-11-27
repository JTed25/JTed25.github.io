using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Blogposts;

public static class PutBlogpost
{
    public static RouteGroupBuilder MapPutBlogpost(
        this RouteGroupBuilder group)
    {
        /*PUT blogpost*/
        group.MapPut("/{id}", async (int id, CreateBlogpostDto dto, PortfolioDbContext db) =>
        {
            var blogpost = await db.Blogposts.FindAsync(id);
            
            if (blogpost == null)
                return Results.NotFound();

            blogpost.Titel = dto.Titel;
            blogpost.Inhoud = dto.Inhoud;
            
            await db.SaveChangesAsync();

            return Results.Ok();
        });

        return group;
    }
}