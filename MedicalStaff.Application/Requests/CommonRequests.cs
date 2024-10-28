using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using System.Runtime.InteropServices.ComTypes;

namespace MedicalStaff.Application.Requests
{ 
        public record GetAllRequest<T> : IRequest<ApiResponse<IEnumerable<T>>>;
        public record GetByIdRequest<T>(int Id) : IRequest<ApiResponse<T>>;
        public record UpdateRequest<T>(T Entity) : IRequest<ApiResponse<string>>;

        //public record AddRequest<T>(T Entity) : IRequest<ApiResponse<T>>;
        public record DeleteRequest<T>(int Id) : IRequest<ApiResponse<string>>;
    

}