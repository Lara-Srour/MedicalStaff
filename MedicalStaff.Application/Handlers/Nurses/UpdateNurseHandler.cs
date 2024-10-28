using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;

namespace MedicalStaff.Application.Handlers.Nurses
{
    public class UpdateNurseHandler(INurseRepository _nurseRepository) : IRequestHandler<UpdateNurseRequest, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(UpdateNurseRequest request, CancellationToken cancellationToken)
        {
            //map from NurseDTO to the entity Nurse
            var nurseDto = request.Entity;
            var nurse = nurseDto.Adapt<Nurse>();
            // Check if the nurse exists
            var existingNurse = await _nurseRepository.GetByIdAsync(nurse.Id);
            if (existingNurse == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Nurse with ID {nurse.Id} does not exist.");
            }
            // Update existing nurse properties
            
            existingNurse.Name = nurseDto.Name;
            existingNurse.DepartmentName = nurseDto.DepartmentName;

            await _nurseRepository.UpdateNurseAsync(existingNurse);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Nurse {nurse.Id} is updated.");
        }
    }
}