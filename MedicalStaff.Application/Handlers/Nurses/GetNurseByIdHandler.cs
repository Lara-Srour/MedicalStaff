using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;

namespace MedicalStaff.Application.Handlers.Nurses
{
    public class GetNurseByIdHandler : IRequestHandler<GetNurseByIdRequest, ApiResponse<NurseDTO>>
    {
        private readonly INurseRepository _nurseRepository;
        public GetNurseByIdHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<ApiResponse<NurseDTO>> Handle(GetNurseByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the nurse exists
            var nurse = await _nurseRepository.GetByIdAsync(request.Id);
            var nurseDto = nurse.Adapt<NurseDTO>();
            if (nurseDto == null)
            {
                return ApiResponse<NurseDTO>.CreateErrorResponse($"Nurse with ID {request.Id} does not exist.");
            }
            
            return ApiResponse<NurseDTO>.CreateSuccessResponse(nurseDto, $"Nurse {nurseDto.Id} is retrieved successfully.");
        }
    }
}
