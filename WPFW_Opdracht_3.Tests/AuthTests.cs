using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace WPFW_Opdracht_3.Tests;

public class AuthTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AuthTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/auth/login",
            new
            {
                Email = "nietbestaand@test.nl",
                Wachtwoord = "FoutWachtwoord"
            });

        // Assert
        Assert.Equal(
            HttpStatusCode.Unauthorized,
            response.StatusCode);
    }
}