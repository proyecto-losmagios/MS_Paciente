using Microsoft.EntityFrameworkCore;
using Domain.Entities;


namespace AccessData {

    public class APIDbContext : DbContext {

        public APIDbContext(DbContextOptions<APIDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Paciente>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }

        public DbSet<Paciente> Pacientes { get; set; }

    }

}