using FluentValidation;
using MedicalStaff.Application.DTOs;

namespace MedicalStaff.Application.Validators
{
    public class RoomValidator : AbstractValidator<RoomDTO>
    {
        public RoomValidator()
        {
            RuleFor(room => room.Number)
                .GreaterThan(0).WithMessage("Room number must be greater than zero.");

            RuleFor(room => room.DepartmentName)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(100).WithMessage("Department name must not exceed 100 characters.");
        }
    }
}