using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using Microsoft.EntityFrameworkCore;
using MedicalStaff.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStaff.Infrastructure.Repositories
{
    public class RoomRepository : CommonRepository<Room>, IRoomRepository
    {
        private readonly MedicalStaffDbContext _context;
        public RoomRepository(MedicalStaffDbContext context) : base(context) { _context = context; }

        public async Task UpdateRoomAsync(Room room)
        {
            // Retrieve the existing room from the database
            var existingRoom = await _context.Rooms.FindAsync(room.Id);
            if (existingRoom == null)
            {
                throw new InvalidOperationException("Room not found.");
            }

            // Check if the room is available
            if (!existingRoom.IsAvailable)
            {
                throw new InvalidOperationException("Room cannot be updated because it is currently reserved.");
            }
            // Check if the department exists
            var existingDepartment = await _context.Departments
                .AnyAsync(d => d.Name == room.DepartmentName);

            if (!existingDepartment)
            {
                throw new InvalidOperationException("Department not found.");
            }

            // If the department exists, add the room
            await UpdateAsync(room);
        }
        public async Task AddRoomAsync(Room room)
        {
            // Check if the department exists
            var existingDepartment = await _context.Departments
                .AnyAsync(d => d.Name == room.DepartmentName);

            if (!existingDepartment)
            {
                throw new InvalidOperationException("Department not found.");
            }

            // If the department exists, add the room
            await AddAsync(room);
        }
        public async Task<IEnumerable<Room>> DisplayAvailableRoomsAsync(string department)
        {
            var existingDepartment = await _context.Departments
                .Where(d => d.Name == department)
                .FirstOrDefaultAsync();

            if (existingDepartment == null)
            {
                // Handle the error as you prefer, e.g., by throwing an exception
                throw new InvalidOperationException("Department not found.");
            }
            var rooms = await _context.Rooms
                .Where(r => r.IsAvailable && r.DepartmentName == department)
                .ToListAsync();
            
            return rooms;
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            // Retrieve the existing room from the database
            var room = await _context.Rooms.FindAsync(roomId);

            // Check if the room is available
            if (!room.IsAvailable)
            {
                throw new InvalidOperationException("Room cannot be deleted because it is currently reserved.");
            }

            // Perform deletion
            await DeleteAsync(roomId);
            await _context.SaveChangesAsync();
        }

    }
}
