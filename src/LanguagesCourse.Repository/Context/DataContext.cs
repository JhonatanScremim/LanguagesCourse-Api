using LanguagesCourse.Domain;
using Microsoft.EntityFrameworkCore;

namespace LanguagesCourse.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student>? Student {get; set;}
        public DbSet<Class>? Class {get; set;}
        public DbSet<Registration>? Registration {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Registration>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.Registrations)
                .HasForeignKey(bc => bc.StudentId);
            
            modelBuilder.Entity<Registration>()
                .HasOne(bc => bc.Class)
                .WithMany(c => c.Registrations)
                .HasForeignKey(bc => bc.ClassId);
        }
    }
}