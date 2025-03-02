using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Features.Queries;
using ManagingRealEstate.API.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingRealEstate.API.Test;

public class GetRealEstateByIdQueryHandlerTests
{
    private readonly Mock<IDbContext> _dbContextMock;
    private readonly GetRealEstateByIdQueryHandler _handler;

    public GetRealEstateByIdQueryHandlerTests()
    {
        _dbContextMock = new Mock<IDbContext>();
        _handler = new GetRealEstateByIdQueryHandler(_dbContextMock.Object);
    }

    [Fact]
    public async Task Handle_RealEstateExists_ReturnsRealEstate()
    {
        // Arrange
        var realEstateId = Guid.NewGuid();
        var realEstate = RealEstate.Create("Title", "Description", 100000, "Location");
        _dbContextMock.Setup(x => x.Set<RealEstate>().FindAsync(new object[] { realEstateId }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(realEstate);

        // Act
        var result = await _handler.Handle(new GetRealEstateByIdQuery { RealEstateId = realEstateId }, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(realEstate, result);
    }

    [Fact]
    public async Task Handle_RealEstateDoesNotExist_ReturnsNull()
    {
        // Arrange
        var realEstateId = Guid.NewGuid();
        _dbContextMock.Setup(x => x.Set<RealEstate>().FindAsync(new object[] { realEstateId }, It.IsAny<CancellationToken>()))
            .ReturnsAsync((RealEstate)null);

        // Act
        var result = await _handler.Handle(new GetRealEstateByIdQuery { RealEstateId = realEstateId }, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
}
