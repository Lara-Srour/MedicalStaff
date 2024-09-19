using MediatR;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class DeleteRequest<T> : IRequest<ApiResponse<string>>
    {
        public int Id { get; }
        public DeleteRequest(int id)
        {
            Id = id;
        }
    }
}