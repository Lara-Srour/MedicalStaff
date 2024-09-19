using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;

namespace MedicalStaff.Application.Requests
{
     public class GetAllRequest<T> : IRequest<ApiResponse<IEnumerable<T>>>
     {

     }
}