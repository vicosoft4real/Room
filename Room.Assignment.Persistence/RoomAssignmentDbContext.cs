using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Room.Assignment.Application.Contracts.Identity;
using Room.Assignment.Domain.Common;
using Room.Assignment.Domain.Entities;

namespace Room.Assignment.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class RoomAssignmentDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILoggedInUserService loggedInUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomAssignmentDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="loggedInUserService"></param>
        public RoomAssignmentDbContext(DbContextOptions<RoomAssignmentDbContext> options,
            ILoggedInUserService loggedInUserService) : base(options)
        {
            this.loggedInUserService = loggedInUserService;
        }


        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        public DbSet<Service> Services { get; set; }


        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoomAssignmentDbContext).Assembly);

            modelBuilder.Entity<Service>().HasData(new List<Service>()
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
            });


        }
        /// <summary>
        /// <para>
        /// Saves all changes made in this context to the database.
        /// </para>
        /// <para>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        /// changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </para>
        /// <para>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTimeOffset.Now;
                        entity.Entity.CreatedBy = loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModifiedDate = DateTime.Now;
                        entity.Entity.LastModifiedBy = loggedInUserService.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
