using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;


namespace MedicalStaff.Application.Requests
{
    public class NurseRequests
    {
        public record GetAllNursesRequest : GetAllRequest<NurseDTO>;
        public record GetNurseByIdRequest(int Id) : GetByIdRequest<NurseDTO>(Id);

        public record GetNursesInDepartmentRequest(string DepartmentName) : IRequest<ApiResponse<IEnumerable<NurseDTO>>>;

        public record AddNurseRequest(string Name, string DepartmentName) : IRequest<ApiResponse<NurseDTO>>;

        public record UpdateNurseRequest(NurseDTO Nurse) : UpdateRequest<NurseDTO>(Nurse);

        public record DeleteNurseRequest(int Id) : DeleteRequest<NurseDTO>(Id);
        
    }
}