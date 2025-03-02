using ManagingRealEstate.API.Features.Commands;
using ManagingRealEstate.API.Features.Queries;
using ManagingRealEstate.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using System.Text;

namespace ManagingRealEstate.API.Test;

public class RealEstateEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<ISender> _senderMock;

    public RealEstateEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _senderMock = new Mock<ISender>();
    }

    [Fact]
    public async Task CreateRealEstate_ReturnsCreated()
    {
        // Arrange
        var command = new CreateRealEstateCommand("Title", "Description", 100000, "Location");
        var realEstateId = Guid.NewGuid();
        _senderMock.Setup(x => x.Send(It.IsAny<CreateRealEstateCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(realEstateId);

        var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/realestate", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetRealEstateById_ReturnsOk()
    {
        // Arrange
        var realEstateId = Guid.NewGuid();
        var realEstate = RealEstate.Create("Title", "Description", 100000, "Location");
        _senderMock.Setup(x => x.Send(It.IsAny<GetRealEstateByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(realEstate);

        // Act
        var response = await _client.GetAsync($"/realestate/{realEstateId}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task DeleteRealEstate_ReturnsNoContent()
    {
        // Arrange
        var realEstateId = Guid.NewGuid();
        _senderMock.Setup(x => x.Send(It.IsAny<DeleteRealEstateCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var response = await _client.DeleteAsync($"/realestate/{realEstateId}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
}
