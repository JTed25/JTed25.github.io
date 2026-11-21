using System.Net;
using Xunit;

namespace WPFW_Opdracht_3.Tests;

public class ProjectTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ProjectTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProjects_ReturnsOk()
    {
        //Arrange

        //Act
        var response = await _client.GetAsync("/api/projects");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
