using MedicalStaff.Application.Interfaces;
using MedicalStaff.Domain;
using Microsoft.EntityFrameworkCore;
using MedicalStaff.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Infrastructure.Repositories
{
    public class PatientRepository : CommonRepository<Patient>, IPatientRepository
    {
        private readonly MedicalStaffDbContext _context;
        public PatientRepository(MedicalStaffDbContext context) : base(context) { _context = context; }

        public async Task UpdatePatientAsync(Patient patient)
        {
            var existingPatient = await _context.Patients.FindAsync(patient.Id);
            if (existingPatient == null)
            {
                throw new InvalidOperationException("Patient not found.");
            }

            // Check if DoctorId exists
            var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == patient.DoctorId);
            if (!doctorExists)
            {
                throw new InvalidOperationException("Doctor not found.");
            }

            var nurseExists = await _context.Nurses.AnyAsync(n => n.Id == patient.NurseId);
            if (!nurseExists)
            {
                throw new InvalidOperationException("Nurse not found.");
            }

            // Room change logic
            if (existingPatient.RoomNumber != patient.RoomNumber)
            {
                var newRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Number == patient.RoomNumber);
                if (newRoom == null || !newRoom.IsAvailable)
                {
                    throw new InvalidOperationException("New room not available.");
                }

                await _context.Database.ExecuteSqlRawAsync("UPDATE Rooms SET IsAvailable = 0 WHERE Number = {0}", newRoom.Number);

                var oldRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Number == existingPatient.RoomNumber);
                if (oldRoom != null)
                {
                    await _context.Database.ExecuteSqlRawAsync("UPDATE Rooms SET IsAvailable = 1 WHERE Number = {0}", oldRoom.Number);
                }
            }

            // Update patient properties
            existingPatient.Name = patient.Name;
            existingPatient.DoctorId = patient.DoctorId;
            existingPatient.NurseId = patient.NurseId;
            existingPatient.RoomNumber = patient.RoomNumber;

            await UpdateAsync(existingPatient);
           
        }


        public async Task AddPatientAsync(Patient patient)
          {
              // Check if DoctorId exists
              var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == patient.DoctorId);
              if (!doctorExists)
              {
                  throw new InvalidOperationException("Doctor not found.");
              }

              // Check if NurseId exists
              var nurseExists = await _context.Nurses.AnyAsync(n => n.Id == patient.NurseId);
              if (!nurseExists)
              {
                  throw new InvalidOperationException("Nurse not found or not available.");
              }

              // Check if RoomNumber exists and available 
              var roomExists = await _context.Rooms.FirstOrDefaultAsync(r => r.Number == patient.RoomNumber && r.IsAvailable);
              if (roomExists == null)
              {
                  throw new InvalidOperationException("Room not found or not avaliable.");
              }

              // If all checks pass, add the patient
              await AddAsync(patient);

              // Update the room's availability directly using a query
              await _context.Database.ExecuteSqlRawAsync(
                  "UPDATE Rooms SET IsAvailable = 0 WHERE Number = {0}", roomExists.Number);

              // Save changes to the database
              await _context.SaveChangesAsync();
          } 



        public async Task  DeletePatientAsync(int patientId)
        {
            var existingPatient = await _context.Patients.FindAsync(patientId);
            if (existingPatient == null)
            {
                throw new InvalidOperationException("Patient not found.");
            }

            // Retrieve the room associated with the patient
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Number == existingPatient.RoomNumber);

            // Delete the patient
            await DeleteAsync(patientId);

            // Mark the room as available
            if (room != null)
            {
                room.IsAvailable = true;
                _context.Rooms.Update(room);
            }

            // Save changes
            await _context.SaveChangesAsync();
        }

    }
}
