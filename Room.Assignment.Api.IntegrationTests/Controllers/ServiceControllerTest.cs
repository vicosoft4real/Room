using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Room.Assignment.Api.IntegrationTests.Base;
using Room.Assignment.Api.Response;
using Room.Assignment.Application.Features.Services.Command;
using Room.Assignment.Application.Features.Services.Query;
using Shouldly;
using Xunit;

namespace Room.Assignment.Api.IntegrationTests.Controllers
{
    public class ServiceControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public ServiceControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task UnAuthorize_Access_To_Search_Should_Return_401()
        {
            var client = factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/v1/service/search?search=app&page=1&size=10");

            response.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Authorize_User_with_Matching_Search_Should_Return_Service()
        {
            var client = await factory.GetAuthenticatedClientAsync();
            var response = await client.GetAsync("/api/v1/service/search?search=app&page=1&size=10");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<Responses<List<ServiceVm>>>(stringResponse);

            responseData.Data.Count.ShouldBe(2);


        }

        [Fact]
        public async Task Activate_Service_Promo_with_ValidId_Should_Succeed()
        {
            var client = await factory.GetAuthenticatedClientAsync();
            var request = new ActivatePromoCodeCommand { Id = "3F9F2D19-441C-4EA3-83E6-E21201702A21" };
            var response = await client.PostAsync("/api/v1/service/activate", Utilities.GetRequestContent(request));

            response.StatusCode.ShouldBe(HttpStatusCode.OK);




        }

        [Fact]
        public async Task Activate_Service_Promo_with_InValidId_Should_Fail()
        {
            var client = await factory.GetAuthenticatedClientAsync();
            var request = new ActivatePromoCodeCommand { Id = "" };
            var response = await client.PostAsync("/api/v1/service/activate", Utilities.GetRequestContent(request));

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);




        }
    }
}