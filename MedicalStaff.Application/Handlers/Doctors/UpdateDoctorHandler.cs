using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using System.Numerics;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Doctors
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorRequest, ApiResponse<string>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<string>> Handle(UpdateDoctorRequest request, CancellationToken cancellationToken)
        {
            //map from DoctorDTO to the entity Doctor
            var doctorDto = request.Entity;
            var doctor = doctorDto.Adapt<Doctor>();
            // Check if the doctor exists
            var existingDoctor = await _doctorRepository.GetByIdAsync(doctor.Id);
            if (existingDoctor == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Doctor with ID {doctorDto.Id} does not exist.");
            }

            // Update existing doctor properties
            existingDoctor.Name = doctorDto.Name;
            existingDoctor.Specialty = doctorDto.Specialty;
            
            await _doctorRepository.UpdateAsync(existingDoctor);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Doctor {doctorDto.Id} is updated.");
        }
    }
}