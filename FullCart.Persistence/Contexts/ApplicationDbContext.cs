using FullCart.Application.Interfaces;
using FullCart.Domain.Common;
using FullCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace FullCart.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService dateTime;
        private readonly IAuthenticatedUserService authenticatedUser;

        public ApplicationDbContext()
        {
            //
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.dateTime = dateTime;
            this.authenticatedUser = authenticatedUser;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = dateTime.NowUtc;
                        entry.Entity.CreatedBy = authenticatedUser.UserId;
                        //entry.Entity.CreatedBy = "CodeDonor";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = dateTime.NowUtc;
                        entry.Entity.CreatedBy = authenticatedUser.UserId;
                        //entry.Entity.LastModifiedBy = "CodeDonor";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //protected override void OnMdoelCreating(ModelBuilder builder)
        //{
        //    foreach (var property in builder.Model.GetEntityTypes()
        //        .SelectMany(t => t.GetProperties())
        //        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        //    {
        //        property.SetColumnType("decimal(18,6)");
        //    }
        //    base.OnModelCreating(builder);
        //}
    }
}
