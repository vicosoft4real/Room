using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Room.Assignment.Application.Contracts.Persistence;
using Room.Assignment.Application.Features.Services.Query;
using Room.Assignment.Application.Profiles;
using Room.Assignment.Application.UnitTest.Mocks;

namespace Room.Assignment.Application.UnitTest.Services.Query
{
    public class ServiceQueryTest
    {
        private readonly IMapper mapper;
        private Mock<IServiceRepository> serviceMock;

        public ServiceQueryTest()
        {
            serviceMock = RepositoryMock.GetServiceRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();


        }

        public async Task Match_Service_Characters_Name_Should_Return_Services()
        {
            //arrange 
            var searchName = "app";
            var handler = new GetServiceQueryHandler(serviceMock.Object, mapper);

            //act 
            var result =  handler.Handle(new GetServiceQuery{Page=1, Size=10, Search= searchName});



        }
    }
}