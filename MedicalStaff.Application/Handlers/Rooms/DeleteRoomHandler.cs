using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;
namespace MedicalStaff.Application.Rooms
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomRequest, ApiResponse<string>>
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ApiResponse<string>> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
        {
            // Check if the room exists
            var existingroom = await _roomRepository.GetByIdAsync(request.Id);
            if (existingroom == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Room with ID {request.Id} does not exist and cannot be deleted.");
            }
            await _roomRepository.DeleteRoomAsync(request.Id);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Room with ID {request.Id} is deleted.");
        }
    }
}