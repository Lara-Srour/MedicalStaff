using MedicalStaff.Application.Interfaces;
using MedicalStaff.Domain;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStaff.Infrastructure.Repositories
{
    public class DoctorRepository : CommonRepository<Doctor>, IDoctorRepository
    {
        private readonly MedicalStaffDbContext _context;
        public DoctorRepository(MedicalStaffDbContext context) : base(context) { _context = context; }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(string specialty)
        {
            var doctors =  await _context.Doctors
                .Where(d => d.Specialty == specialty)
                .ToListAsync();
            return doctors;
        }

        public async Task<IEnumerable<Patient>> GetDoctorPatientsAsync(int id)
        {
            var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == id);
            if (!doctorExists)
            {
                throw new InvalidOperationException("Doctor not found.");
            }
            var patients = await _context.Patients
                .Where(p => p.DoctorId == id)
                .ToListAsync();
            return patients;
        }

    }
}
