using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Models.DTO_s.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
    public class TripRateContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TripRateDefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().Property<DateTime>("CreatedDate");
            modelBuilder.Entity<Trip>().Property<DateTime>("UpdatedDate");
            //modelBuilder.Entity<Trip>().Property<int>("UserCreated");
            //modelBuilder.Entity<Trip>().Property<int>("UserUpdated");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                           .Where(x => x.State == EntityState.Added
                                    || x.State == EntityState.Modified);

            foreach (var item in entries)
            {
                item.Property("UpdatedDate").CurrentValue = DateTime.Now;

                if (item.State == EntityState.Added)
                    item.Property("CreatedDate").CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync();
        }

        public Response ResponseSaveChangesAsync()
        {
            try
            {
                var changedRecords = this.SaveChanges();

                if (changedRecords > 0)
                {
                    return new Response()
                    {
                        Success = true,
                        Message = "Success"
                    };
                }
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Success = false,
                    Message = string.Format("Error: {0}", ex.Message)
                };
            }
        }

        public void ValidateStateOfEntity<T>(T entity)
        {
            if (this.Entry(entity).State == EntityState.Detached)
                throw new Exception(String.Format("Can't save the entity, state is invalid. State: {0}", EntityState.Detached.ToString()));
        }
    }
}
