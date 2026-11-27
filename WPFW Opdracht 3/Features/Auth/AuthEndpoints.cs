namespace Backend.Features.Auth;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(
        this WebApplication app)
    {
        var group = app.MapGroup("/api/auth");

        group.MapRegister();
        group.MapLogin();
    }
}