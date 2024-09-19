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
    public class AddDoctorHandler : IRequestHandler<AddDoctorRequest, ApiResponse<DoctorDTO>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public AddDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<DoctorDTO>> Handle(AddDoctorRequest request, CancellationToken cancellationToken)
        {
            //map DoctorDTO to the entity Doctor
            var doctorDto = request.Entity;
            var doctor = doctorDto.Adapt<Doctor>();

            // Check if the doctor already exists
            var existingDoctor = await _doctorRepository.GetByIdAsync(doctor.Id);
            if (existingDoctor != null)
            {
                // Handle the error, e.g., throw an exception or return a specific error response
                return ApiResponse<DoctorDTO>.CreateErrorResponse($"Doctor with ID {doctorDto.Id} already exists.");
            }
            await _doctorRepository.AddAsync(doctor);
            return ApiResponse<DoctorDTO>.CreateSuccessResponse(doctorDto, $"Doctor {doctorDto.Id} is added successfully");
        }
    }
}