using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAcess.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {


            try
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                    , sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null
                            );
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(builder => builder.HasKey(x => x.EventsId));
            modelBuilder.Entity<Tickets>(builder => builder.HasKey(x =>x.TicketsId));
            modelBuilder.Entity<Users>(builder => builder.HasNoKey());
            modelBuilder.Entity<Profiles>(builder => builder.HasNoKey());

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Events> Events { get; set; }
    }

}
