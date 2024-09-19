using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class NurseRequests
    {

        public class GetAllNursesRequest : GetAllRequest<NurseDTO>
        {

        }
        public class GetNurseByIdRequest : GetByIdRequest<NurseDTO>
        {
            public GetNurseByIdRequest(int id) : base(id) { }
        }

        public class GetNursesInDepartmentRequest : IRequest<ApiResponse<IEnumerable<NurseDTO>>>
        {
            public string DepartmentName { get; }
            public GetNursesInDepartmentRequest(string departmentName)
            {
                DepartmentName = departmentName;
            }
        }

        public class AddNurseRequest : AddRequest<NurseDTO>
        {
            public AddNurseRequest(NurseDTO nurse) : base(nurse) { }
        }

        public class UpdateNurseRequest : UpdateRequest<NurseDTO>
        {
            public UpdateNurseRequest(NurseDTO nurse) : base(nurse) { }
        }

        public class DeleteNurseRequest : DeleteRequest<NurseDTO>
        {
            public DeleteNurseRequest(int id) : base(id) { }
        }
    }
}