using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;

namespace MedicalStaff.Application.Handlers.Nurses
{
    public class UpdateNurseHandler : IRequestHandler<UpdateNurseRequest, ApiResponse<string>>
    {
        private readonly INurseRepository _nurseRepository;

        public UpdateNurseHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<ApiResponse<string>> Handle(UpdateNurseRequest request, CancellationToken cancellationToken)
        {
            //map from NurseDTO to the entity Nurse
            var nurseDto = request.Entity;
            var nurse = nurseDto.Adapt<Nurse>();
            // Check if the nurse exists
            var existingNurse = await _nurseRepository.GetByIdAsync(nurse.Id);
            if (existingNurse == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Nurse with ID {nurseDto.Id} does not exist.");
            }
            // Update existing nurse properties
            existingNurse.Name = nurseDto.Name;
            existingNurse.DepartmentName = nurseDto.DepartmentName;

            await _nurseRepository.AddNurseAsync(existingNurse);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Nurse {nurseDto.Id} is updated.");
        }
    }
}