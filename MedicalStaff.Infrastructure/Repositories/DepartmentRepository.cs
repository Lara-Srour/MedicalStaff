using MedicalStaff.Application;
using MedicalStaff.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalStaff.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MedicalStaff.Application.DTOs;

namespace MedicalStaff.Infrastructure.Repositories
{
    public class DepartmentRepository : CommonRepository<Department>, IDepartmentRepository
    {
        private readonly MedicalStaffDbContext _context;

        public DepartmentRepository(MedicalStaffDbContext context) : base(context) { _context = context; }

        public async Task UpadateDepartnmentAsync(Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(department.Id);
            if (existingDepartment == null)
            {
                throw new InvalidOperationException("Department not found");
            }

            if (existingDepartment.Name != department.Name) 
            {
                var reservedRoomsExist = await _context.Rooms.AnyAsync(r => r.DepartmentName == existingDepartment.Name && !r.IsAvailable);
                if (reservedRoomsExist)
                {
                    throw new InvalidOperationException("There is a reserved rooms in the Department, can't be updated.");
                }
            }

            existingDepartment.Name = department.Name;
            await UpdateAsync(existingDepartment);

        }

        public async Task<IEnumerable<Room>> DisplayRoomsInDepartmentAsync(string depName)
        {
            // Check if the department exists
            var existingDepartment = await _context.Departments
                .AnyAsync(d => d.Name == depName);

            if (!existingDepartment)
            {
                throw new InvalidOperationException("Department not found.");
            }
            var rooms = await _context.Rooms
                .Where(r => r.DepartmentName == depName)
                .ToListAsync();
               
            return rooms;
        }

        public async Task DeleteDepartmentAsync(int departmentId)
        {
            var existingDepartment = await _context.Departments.FindAsync(departmentId);
            if (existingDepartment == null)
            {
                throw new InvalidOperationException("Department not found");
            }

            var reservedRoomsExist = await _context.Rooms.AnyAsync(r => r.DepartmentName == existingDepartment.Name && !r.IsAvailable);
            if (reservedRoomsExist)
            {
                throw new InvalidOperationException("There is a reserved rooms in the Department, can't be deleted.");
            }

            await DeleteAsync(departmentId);
        }

    }
}
