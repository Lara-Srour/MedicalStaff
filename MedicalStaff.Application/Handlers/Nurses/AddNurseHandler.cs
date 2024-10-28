using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;


namespace MedicalStaff.Application.Handlers.Nurses
{
    public class AddNurseHandler(INurseRepository _nurseRepository) : IRequestHandler<AddNurseRequest, ApiResponse<NurseDTO>>
    {
        public async Task<ApiResponse<NurseDTO>> Handle(AddNurseRequest request, CancellationToken cancellationToken)
        {
            //map NurseDTO to the entity Nurse
            var (name, departmentName) = request;
            var nurse = new Nurse(name, departmentName);
            await _nurseRepository.AddNurseAsync(nurse);
            
            return ApiResponse<NurseDTO>.CreateSuccessResponse(nurse.Adapt<NurseDTO>(), $"Nurse {nurse.Id} is added successfully");
        }
    }
}