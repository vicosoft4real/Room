using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Moq;
using Room.Assignment.Application.Contracts.Persistence;
using Room.Assignment.Domain.Entities;

namespace Room.Assignment.Application.UnitTest.Mocks
{
    public class RepositoryMock
    {
        public static Mock<IServiceRepository> GetServiceRepository()
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

            var mockRepository = new Mock<IServiceRepository>();


            mockRepository.Setup(repo => repo.ActivatePromoCode(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(
                    (string id, CancellationToken _) =>
                    {
                        var service = services.FirstOrDefault(x => x.Id == Guid.Parse(id));
                        if (service != null)
                        {
                            service.IsActivated = true;
                            return (true, "The service has been activated successfully");
                        }

                        return (false, "Not found");

                    });

            mockRepository.Setup(repo => repo.GetById(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(
                (string id, CancellationToken _) =>
                {
                    return services.FirstOrDefault(x => x.Id == Guid.Parse(id));
                });

            mockRepository.Setup(repo => repo.GetAll(CancellationToken.None)).ReturnsAsync((CancellationToken _) => services);

            mockRepository
                .Setup(repo => repo.GetBy(It.IsAny<Expression<Func<Service, bool>>>(), CancellationToken.None))
                .ReturnsAsync((Expression<Func<Service, bool>> predicate, CancellationToken _) => services.AsQueryable().Where(predicate));


            return mockRepository;
        }
    }
}