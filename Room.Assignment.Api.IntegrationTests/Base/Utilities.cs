using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Room.Assignment.Domain.Entities;
using Room.Assignment.Persistence;

namespace Room.Assignment.Api.IntegrationTests.Base
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
        public static void InitializeDbForTests(RoomAssignmentDbContext context)
        {
            var services = new List<Service>()
            {
                new()
                {
                    Name = "Sitcostructor.io",
                    Description = "Description",
                    IsActivated = false,
                    PromotionCode = "promo123",
                    Id = Guid.Parse("{3F9F2D19-441C-4EA3-83E6-E21201702A21}")
                },
                new()
                {
                    Name = "Appvision.io",
                    Description = "Description",
                    IsActivated = false,
                    PromotionCode = "promo123",
                    Id = Guid.Parse("{5EF1F6FB-A91E-4E70-B687-FAC2E2AD12C8}")
                },
                new()
                {
                    Name = "Analytic.io",
                    Description = "Description",
                    IsActivated = false,
                    PromotionCode = "promo123",
                    Id = Guid.Parse("{66D40A1D-1F4C-4EF9-8C8B-3F360757FC1B}")
                },
                new()
                {
                    Name = "Analytic2.io",
                    Description = "Description",
                    IsActivated = false,
                    PromotionCode = "promo123",
                    Id = Guid.Parse("{787426C5-B989-4961-AA68-F3357069E941}")
                },
                new()
                {
                    Name = "Appvision2.io",
                    Description = "Description",
                    IsActivated = false,
                    PromotionCode = "promo123",
                    Id = Guid.Parse("{E1BBB5FE-E521-4E82-B30C-C8A25CBA6BDF}")
                },
                new()
                {
                    Name = "Sitcostructor2.io",
                    Description = "Description",
                    IsActivated = false,
                    PromotionCode = "promo123",
                    Id = Guid.Parse("{2AE7E9C0-35EC-48B7-855C-BE7E93469074}")
                },

            };
            context.Services.AddRange(services);

            context.SaveChanges();
        }
    }
}