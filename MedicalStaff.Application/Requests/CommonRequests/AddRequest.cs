using MediatR;
using MedicalStaff.Application.Resposne;


namespace MedicalStaff.Application.Requests
{
    public class AddRequest<T> : IRequest<ApiResponse<T>>
    {
        public T Entity { get; }

        public AddRequest(T entity)
        {
            Entity = entity;
        }
    }
}