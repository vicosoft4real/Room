using AutoMapper;
using Moq;
using Room.Assignment.Application.Contracts.Persistence;
using Room.Assignment.Application.Features.Services.Command;
using Room.Assignment.Application.Profiles;
using Room.Assignment.Application.UnitTest.Mocks;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Room.Assignment.Application.UnitTest.Services.Command
{
    public class ActivateBonusTest
    {
        private readonly IMapper mapper;
        private Mock<IServiceRepository> serviceMock;
        public ActivateBonusTest()
        {
            serviceMock = RepositoryMock.GetServiceRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Valid_ServiceId_Should_Activate_Successfully()
        {
            //arrange 
            var handler = new ActivatePromoCodeCommandHandler(serviceMock.Object);
            var serviceId = "5EF1F6FB-A91E-4E70-B687-FAC2E2AD12C8";

            //act
            (bool succeed, string message, string[] validationError) = await handler.Handle(new ActivatePromoCodeCommand { Id = serviceId }, CancellationToken.None);

            //assert
            succeed.ShouldBeTrue();


        }

        [Fact]
        public async Task InValid_ServiceId_Should_Fail_By_Validation()
        {
            //arrange 
            var handler = new ActivatePromoCodeCommandHandler(serviceMock.Object);
            var serviceId = "";

            //act
            (bool succeed, string message, string[] validationError) = await handler.Handle(new ActivatePromoCodeCommand { Id = serviceId }, CancellationToken.None);

            //assert

            validationError.Length.ShouldBe(1);
            succeed.ShouldBeFalse();


        }

        [Fact]
        public async Task The_Activated_Record_Should_Have_Its_IsActivated_True()
        {
            //arrange 
            var handler = new ActivatePromoCodeCommandHandler(serviceMock.Object);
            var serviceId = "5EF1F6FB-A91E-4E70-B687-FAC2E2AD12C8";

            //act
            (bool succeed, string message, string[] validationError) = await handler.Handle(new ActivatePromoCodeCommand { Id = serviceId }, CancellationToken.None);
            var activatedRcord = await serviceMock.Object.GetById(serviceId);
            //assert

            activatedRcord.IsActivated.ShouldBeTrue();




        }
    }
}
