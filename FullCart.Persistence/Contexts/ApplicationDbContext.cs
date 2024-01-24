using FullCart.Application.Interfaces;
using FullCart.Domain.Common;
using FullCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.dateTime = dateTime;
        }

        public DbSet<Brand> Brands { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = dateTime.NowUtc;
                        entry.Entity.CreatedBy = "CodeDonor";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
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
