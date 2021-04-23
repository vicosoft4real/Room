using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Room.Assignment.Application.Models.Authentication;
using Room.Assignment.Persistence;

namespace Room.Assignment.Api.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                services.AddDbContext<RoomAssignmentDbContext>(options =>
                {
                    options.UseInMemoryDatabase("RoomServiceDbContextInMemoryTest");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<RoomAssignmentDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                context.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbForTests(context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                }


            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
        public async Task<HttpClient> GetAuthenticatedClientAsync()
        {
            return await GetAuthenticatedClientAsync("vicosoft4real@gmail.com", "P@ssw0rd123");
        }
        public async Task<HttpClient> GetAuthenticatedClientAsync(string userName, string password)
        {
            var client = CreateClient();

            var token = await GetAccessTokenAsync(client, userName, password);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            return client;
        }
        private async Task<string> GetAccessTokenAsync(HttpClient client, string userName, string password)
        {
            var request = new AuthenticationRequest()
            {
                Email = userName,
                Password = password
            };
            var response = await client.PostAsync("/api/Account/authenticate", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AuthenticationResponse>(stringResponse);

            return token.Token;



        }


    }
}