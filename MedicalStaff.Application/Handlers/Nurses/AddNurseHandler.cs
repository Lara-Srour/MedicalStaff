using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;


namespace MedicalStaff.Application.Handlers.Nurses
{
    public class AddNurseHandler : IRequestHandler<AddNurseRequest, ApiResponse<NurseDTO>>
    {
        private readonly INurseRepository _nurseRepository;

        public AddNurseHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<ApiResponse<NurseDTO>> Handle(AddNurseRequest request, CancellationToken cancellationToken)
        {
            //map NurseDTO to the entity Nurse
            var nurseDto = request.Entity;
            var nurse = nurseDto.Adapt<Nurse>();
            // Check if the nurse already exists
            var existingNurse = await _nurseRepository.GetByIdAsync(nurse.Id);
            if (existingNurse != null)
            {
                // Handle the error, e.g., throw an exception or return a specific error response
                return ApiResponse<NurseDTO>.CreateErrorResponse($"Nurse with ID {nurseDto.Id} already exists.");
            }
            await _nurseRepository.AddNurseAsync(nurse);
            return ApiResponse<NurseDTO>.CreateSuccessResponse(nurseDto, $"Nurse {nurseDto.Id} is added successfully");
        }
    }
}