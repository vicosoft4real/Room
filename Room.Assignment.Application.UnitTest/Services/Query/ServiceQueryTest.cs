using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Room.Assignment.Application.Contracts.Persistence;
using Room.Assignment.Application.Features.Services.Query;
using Room.Assignment.Application.Profiles;
using Room.Assignment.Application.UnitTest.Mocks;
using System.Threading;
using Shouldly;
using System.Collections.Generic;
using Xunit;

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

        [Fact]
        public async Task Match_Service_Characters_Name_Should_Return_Services()
        {
            //arrange 
            var searchName = "app";
            var handler = new GetServiceQueryHandler(serviceMock.Object, mapper);

            //act 
            var result = await handler.Handle(new GetServiceListQuery { Page = 1, Size = 10, Search = searchName }, CancellationToken.None);

            //result 
            result.ShouldBeOfType<List<ServiceVm>>();

            result.Count.ShouldBe(2);



        }

        [Fact]
        public async Task Match_Service_Characters_Name_Should_Ingnore_Case_Sensitivity()
        {
            //arrange 
            var searchName = "APpViS";
            var handler = new GetServiceQueryHandler(serviceMock.Object, mapper);

            //act 
            var result = await handler.Handle(new GetServiceListQuery { Page = 1, Size = 10, Search = searchName }, CancellationToken.None);

            //result 
            result.ShouldBeOfType<List<ServiceVm>>();

            result.Count.ShouldBe(2);


        }

        [Fact]
        public async Task Empty_Imput_Should_Match_All_Possible_Service()
        {
            //arrange 
            var searchName = "";
            var handler = new GetServiceQueryHandler(serviceMock.Object, mapper);

            //act 
            var result = await handler.Handle(new GetServiceListQuery { Page = 1, Size = 10, Search = searchName }, CancellationToken.None);

            //result 
            result.ShouldBeOfType<List<ServiceVm>>();

            result.Count.ShouldBe(6);


        }
        [Fact]
        public async Task When_Page_Size_is_Zero_Should_Use_Defaul_Page_Size()
        {
            //arrange 
            var searchName = "";
            var handler = new GetServiceQueryHandler(serviceMock.Object, mapper);

            //act 
            var result = await handler.Handle(new GetServiceListQuery { Page = 1, Size = 0, Search = searchName }, CancellationToken.None);

            //result 
            result.ShouldBeOfType<List<ServiceVm>>();

            result.Count.ShouldBe(6);


        }

        [Fact]
        public async Task When_Page_Size_is_Given_Should_Return_Given_Record_Count()
        {
            //arrange 
            var searchName = "";
            int size = 3;
            var handler = new GetServiceQueryHandler(serviceMock.Object, mapper);

            //act 
            var result = await handler.Handle(new GetServiceListQuery { Page = 1, Size = size, Search = searchName }, CancellationToken.None);

            //result 
            result.ShouldBeOfType<List<ServiceVm>>();

            result.Count.ShouldBe(size);


        }
    }
}