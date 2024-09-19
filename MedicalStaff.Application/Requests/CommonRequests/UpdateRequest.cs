using MediatR;
using MedicalStaff.Application.Resposne;

public class UpdateRequest<T> : IRequest<ApiResponse<string>>
{
    public T Entity { get; }

    public UpdateRequest(T entity)
    {
        Entity = entity;
    }
}