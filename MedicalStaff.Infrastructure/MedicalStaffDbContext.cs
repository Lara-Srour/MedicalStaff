using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalStaff.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedicalStaff.Infrastructure
{
    public class MedicalStaffDbContext : DbContext
    {
        public MedicalStaffDbContext(DbContextOptions<MedicalStaffDbContext> options)
            : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; } = null!; 
        public DbSet<Nurse> Nurses { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=medicalstaff.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Configures Id to be auto-generated

            modelBuilder.Entity<Nurse>()
                .Property(n => n.Id)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            
        }
    }
}
