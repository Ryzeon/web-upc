using pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using pratica_pc2_1.API.Hr.Domain.Model.Aggregates;

namespace pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Configuration
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Place here your entities configuration
            builder.Entity<Reservation>().ToTable("reservations");
            // Set the primary key and autoincrement
            builder.Entity<Reservation>().HasKey(r => r.Id);
            builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            
            builder.Entity<Reservation>().Property(r => r.CustomerName).IsRequired();
            builder.Entity<Reservation>().Property(r => r.CompanyName).IsRequired();
            builder.Entity<Reservation>().Property(r => r.Email).IsRequired();
            builder.Entity<Reservation>().Property(r => r.ServiceType).IsRequired();
            builder.Entity<Reservation>().Property(r => r.StartDate).IsRequired();
            builder.Entity<Reservation>().Property(r => r.EndDate).IsRequired();
            
            
            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
