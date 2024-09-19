using MediatR;
using MedicalStaff.Domain;
using MedicalStaff.Application.Resposne;

public class GetByIdRequest<T> : IRequest<ApiResponse<T>>
{
    public int Id { get; }

    public GetByIdRequest(int id)
    {
        Id = id;
    }
}