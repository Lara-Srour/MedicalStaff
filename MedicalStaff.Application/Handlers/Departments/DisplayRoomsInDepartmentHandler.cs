using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using static MedicalStaff.Application.Requests.DepartmentRequests;
using System.Collections.Generic;


namespace MedicalStaff.Application.Handlers.Departments
{
    public class DisplayRoomsInDepartmentHandler(IDepartmentRepository _departmentRepository) : IRequestHandler<DisplayRoomsInDepartmentRequest, ApiResponse<IEnumerable<RoomDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<RoomDTO>>> Handle(DisplayRoomsInDepartmentRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _departmentRepository.DisplayRoomsInDepartmentAsync(request.DepartmentName);
            // Check if any rooms were found
            if (rooms == null || !rooms.Any())
            {
                return ApiResponse<IEnumerable<RoomDTO>>.CreateErrorResponse($"No rooms found in the {request.DepartmentName} department.");
            }

            // Return a success response with the list of RoomDTOs
            return ApiResponse<IEnumerable<RoomDTO>>.CreateSuccessResponse(rooms.Adapt<IEnumerable<RoomDTO>>(), $"List of rooms in {request.DepartmentName} department is successfully retrieved.");

        }
    }       
}