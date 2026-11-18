using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Blogposts;

public static class DeleteBlogpost
{
    public static RouteGroupBuilder MapDeleteBlogpost(
        this RouteGroupBuilder group)
    {
        /*DELETE blogpost*/
        group.MapDelete("/{id}", async (int id, PortfolioDbContext db) =>
        {
            var blogpost = await db.Blogposts.FindAsync(id);

            if (blogpost == null)
                return Results.NotFound();

            db.Blogposts.Remove(blogpost);

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        return group;
    }
}