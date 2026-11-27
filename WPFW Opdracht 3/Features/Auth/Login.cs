using Microsoft.AspNetCore.Identity;
using Backend.DTOs;

namespace Backend.Features.Auth;

public static class Login
{
    public static RouteGroupBuilder MapLogin(
        this RouteGroupBuilder group)
    {
        group.MapPost("/login", async (
            LoginDto dto, 
            SignInManager<IdentityUser> signInManager) =>
        {
            var result = await signInManager.PasswordSignInAsync(
                dto.Email,
                dto.Wachtwoord,
                isPersistent: false,
                lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Results.Unauthorized();
            }

            return Results.Ok("Succesvol ingelogd.");
        });

        return group;
    }
}