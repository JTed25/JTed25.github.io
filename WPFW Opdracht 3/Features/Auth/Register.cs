using Microsoft.AspNetCore.Identity;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Auth;

public static class Register
{
    public static RouteGroupBuilder MapRegister(
        this RouteGroupBuilder group)
    {
        group.MapPost("/register", async (
            RegisterDto dto,
            UserManager<IdentityUser> userManager) =>
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await userManager.CreateAsync(
                user, dto.Wachtwoord);
            
            if (!result.Succeeded)
            {
                return Results.BadRequest(result.Errors);
            }

            await userManager.AddToRoleAsync(
                user, "Gast");

            return Results.Ok("Gebruiker geregistreerd.");
        });

        return group;
    }
}
