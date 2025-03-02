using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Features.Commands;
using ManagingRealEstate.API.Models;
using Moq;

namespace ManagingRealEstate.API.Test
{

    public class DeleteRealEstateCommandHandlerTests
    {
        private readonly Mock<IDbContext> _dbContextMock;
        private readonly DeleteRealEstateCommandHandler _handler;

        public DeleteRealEstateCommandHandlerTests()
        {
            _dbContextMock = new Mock<IDbContext>();
            _handler = new DeleteRealEstateCommandHandler(_dbContextMock.Object);
        }

        [Fact]
        public async Task Handle_RealEstateExists_ReturnsTrue()
        {
            // Arrange
            var realEstateId = Guid.NewGuid();
            var realEstate = RealEstate.Create("Title", "Description", 100000, "Location");
            _dbContextMock.Setup(x => x.Set<RealEstate>().FindAsync(new object[] { realEstateId }, It.IsAny<CancellationToken>()))
                .ReturnsAsync(realEstate);
            _dbContextMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(new DeleteRealEstateCommand { RealEstateId = realEstateId }, CancellationToken.None);

            // Assert
            Assert.True(result);
            _dbContextMock.Verify(x => x.Set<RealEstate>().Remove(realEstate), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_RealEstateDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var realEstateId = Guid.NewGuid();
            _dbContextMock.Setup(x => x.Set<RealEstate>().FindAsync(new object[] { realEstateId }, It.IsAny<CancellationToken>()))
                .ReturnsAsync((RealEstate)null);

            // Act
            var result = await _handler.Handle(new DeleteRealEstateCommand { RealEstateId = realEstateId }, CancellationToken.None);

            // Assert
            Assert.False(result);
            _dbContextMock.Verify(x => x.Set<RealEstate>().Remove(It.IsAny<RealEstate>()), Times.Never);
            _dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}
