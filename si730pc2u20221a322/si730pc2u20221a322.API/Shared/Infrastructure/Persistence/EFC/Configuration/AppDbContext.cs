using si730pc2u20221a322.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;

namespace si730pc2u20221a322.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        /// <summary>
        /// DbConext configuration for the entities
        /// - Apply SnakeCase Naming Convention
        /// - Apply Pluralized Table Naming Convention
        /// </summary>
        /// <param name="builder"></param>
        /// <author>Alex Avila Asto (u20221a322) </author>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Place here your entities configuration
            builder.Entity<Plant>().ToTable("plants");
            builder.Entity<Plant>().HasKey(p => p.Id);
            builder.Entity<Plant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Plant>().Property(p => p.CommonName).IsRequired().HasMaxLength(50);
            builder.Entity<Plant>().Property(p => p.ScientificName).IsRequired().HasMaxLength(150);
            builder.Entity<Plant>().Property(p => p.WateringLevelId).IsRequired();
            builder.Entity<Plant>().Property(p => p.OtherName).HasMaxLength(360);
            builder.Entity<Plant>().Property(p => p.ReferenceImageUrl).IsRequired();
            
            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
