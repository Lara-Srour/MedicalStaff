using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using System.Collections.Generic;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Handlers.Doctors
{
    public class GetDoctorPatientsHandler : IRequestHandler<GetDoctorPatientsRequest, ApiResponse<IEnumerable<PatientDTO>>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorPatientsHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<IEnumerable<PatientDTO>>> Handle(GetDoctorPatientsRequest request, CancellationToken cancellationToken)
        {
            var patients = await _doctorRepository.GetDoctorPatientsAsync(request.DoctorId);
            var patientDtos = patients.Adapt<IEnumerable<PatientDTO>>();

            if (patientDtos == null || !patientDtos.Any())
            {
                return ApiResponse<IEnumerable<PatientDTO>>.CreateErrorResponse($"No patients found for doctor {request.DoctorId}.");
            }
            return ApiResponse<IEnumerable<PatientDTO>>.CreateSuccessResponse(patientDtos, $"List of patients of doctor {request.DoctorId} is successfully retrieved.");
        }
    }
}
