using MedicalStaff.Application.Interfaces;
using MedicalStaff.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStaff.Infrastructure.Repositories
{
    public class NurseRepository : CommonRepository<Nurse>, INurseRepository
    {
        private readonly MedicalStaffDbContext _context;
        public NurseRepository(MedicalStaffDbContext context) : base(context) { _context = context; }

        public async Task UpdateNurseAsync(Nurse nurse)
        {
            // Check if the department exists
            var existingDepartment = await _context.Departments
                .AnyAsync(d => d.Name == nurse.DepartmentName);

            if (!existingDepartment)
            {
                throw new InvalidOperationException("Department not found.");
            }

            // If the department exists, add the nurse
            await UpdateAsync(nurse);
        }
        public async Task AddNurseAsync(Nurse nurse)
        {
            // Check if the department exists
            var existingDepartment = await _context.Departments
                .AnyAsync(d => d.Name == nurse.DepartmentName);
                
            if (!existingDepartment)
            {
                throw new InvalidOperationException("Department not found.");
            }

            // If the department exists, add the nurse
            await AddAsync(nurse);
        }
        public async Task<IEnumerable<Nurse>> GetNursesInDepartmentAsync(string department)
        {
            var existingDepartment = await _context.Departments
                .Where(d => d.Name == department)
                .FirstOrDefaultAsync();

            if (existingDepartment == null)
            {
                // Handle the error as you prefer, e.g., by throwing an exception
                throw new InvalidOperationException("Department not found.");
            }
            var nurses = await _context.Nurses
                .Where(n => n.DepartmentName == department)
                .ToListAsync();
            return nurses;
        }

    }
}
