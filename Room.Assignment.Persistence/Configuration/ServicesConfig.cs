using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Room.Assignment.Domain.Entities;

namespace Room.Assignment.Persistence.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Room.Assignment.Domain.Entities.Services}</cref>
    /// </seealso>
    public class ServicesConfig : IEntityTypeConfiguration<Service>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref>
        ///     <name>TEntity</name>
        /// </typeparamref>
        /// .
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.IsActivated).IsRequired();
            builder.Property(x => x.PromotionCode).HasMaxLength(20);
        }
    }
}