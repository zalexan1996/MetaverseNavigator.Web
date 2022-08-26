using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MN.Data
{
    public class Persona5Context : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLlocaldb;Initial Catalog=Persona5";


        public Persona5Context(DbContextOptions<Persona5Context> options) : base(options)
        { }
        public Persona5Context() : base(new DbContextOptions<Persona5Context>())
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);


            // Only log sensitive info to console in debug mode.
#if DEBUG
            optionsBuilder
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Creates the model relationships for the Identity Framework
            base.OnModelCreating(modelBuilder);

            // Creates our model relationships
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

        }
    }
}
