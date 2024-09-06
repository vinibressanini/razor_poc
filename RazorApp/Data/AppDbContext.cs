using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorApp.Models;

namespace RazorApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
                entity.Property(e => e.Email).HasColumnName("Email").IsRequired();
                entity.HasMany(t => t.Courses).WithMany(t => t.Students)
                .UsingEntity("PersonCourse",
                l => l.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonId").HasPrincipalKey("Id"),
                r => r.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseId").HasPrincipalKey("Id"),
                j => j.HasKey("PersonId","CourseId"));
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
                entity.HasMany(t => t.Students).WithMany(t => t.Courses)
                .UsingEntity("PersonCourse",
                l => l.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseId").HasPrincipalKey("Id"),
                r => r.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonId").HasPrincipalKey("Id"),
                j => j.HasKey("PersonId", "CourseId"));
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
    }
}
