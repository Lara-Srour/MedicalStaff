using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using System.Numerics;
using static MedicalStaff.Application.Requests.DoctorRequests;


namespace MedicalStaff.Application.Handlers.Doctors
{
    public class AddDoctorHandler(IDoctorRepository _doctorRepository) : IRequestHandler<AddDoctorRequest, ApiResponse<DoctorDTO>>
    {
        public async Task<ApiResponse<DoctorDTO>> Handle(AddDoctorRequest request, CancellationToken cancellationToken)
        {
            var (name, specialty) = request;
            var doctor = new Doctor(name, specialty);
            await _doctorRepository.AddAsync(doctor);
            return ApiResponse<DoctorDTO>.CreateSuccessResponse(doctor.Adapt<DoctorDTO>(), $"Doctor {doctor.Id} is added successfully");
        }
    }
}