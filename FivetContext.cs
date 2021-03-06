using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Fivet.ZeroIce.model;
namespace Fivet.Dao
{
    public class FivetContext : DbContext
    {
        /// <summary>
        /// Connection to the Db
        /// </summary>
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Ficha> Fichas {get; set;}
        public DbSet<Control> Controles {get; set;}
        public DbSet<Examen> Examenes {get;set}
        
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=fivet.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Persona 
            modelBuilder.Entity<Persona>(p => 
            {
                p.HasKey(p => p.uid);
                p.Property(p => p.email).IsRequired();
                p.HasIndex(p => p.email).IsUnique();
            });

            // Ficha
            modelBuilder.Entity<Ficha>(f =>
            {
                f.HasKey(f => f.uid);
                f.Property(f => f.numeroRegistro).IsRequired();

            });

            // Control
            modelBuilder.Entity<Control>(c =>
            {
                c.HasKey(c => c.uid);
            });
            


            // Insert data to db
            modelBuilder.Entity<Persona>().HasData(
                new Persona()
                {
                    uid = 1,
                    nombre = "Patricio",
                    direccion = "Casa 123",
                    email = "mail@mail.com"

                } 
            );
        }





        


    }
}