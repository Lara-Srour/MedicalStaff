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

    }
}
