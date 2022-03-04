using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Models
{
    public class TripRateContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TripRateDefaultConnection"));
        }

        public Response ResponseSaveChanges()
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
