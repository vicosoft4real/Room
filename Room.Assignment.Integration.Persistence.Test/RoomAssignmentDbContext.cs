using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Room.Assignment.Application.Contracts.Identity;
using Room.Assignment.Domain.Entities;
using Room.Assignment.Persistence;
using Shouldly;
using Xunit;

namespace Room.Assignment.Integration.Persistence.Test
{
    public class RoomAssignmentDbContextTest
    {
        private readonly RoomAssignmentDbContext roomAssignmentDbContext;
        private readonly string userId;
        public RoomAssignmentDbContextTest()
        {
            userId = "00000000-0000-0000-0000-000000000000";
            var dbOptions = new DbContextOptionsBuilder<RoomAssignmentDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            loggedInUserServiceMock.Setup(m => m.UserId).Returns(userId);
            roomAssignmentDbContext = new RoomAssignmentDbContext(dbOptions, loggedInUserServiceMock.Object);
        }

        [Fact]
        public async Task CreatedBy_Should_Be_Set_After_SaveChanges()
        {
            //arrange
            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = "Service Test",
                Description = "This is service test",
                PromotionCode = "codes",
                IsActivated = false
            };

            // act
            await roomAssignmentDbContext.Services.AddAsync(service);

            await roomAssignmentDbContext.SaveChangesAsync(CancellationToken.None);

            //assert
            service.CreatedBy.ShouldBe(userId);

        }


    }
}
