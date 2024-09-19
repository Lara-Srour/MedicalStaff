using FluentValidation;
using MedicalStaff.Application.DTOs;

namespace MedicalStaff.Application.DtoValidators
{
    public class DepartmentValidator : AbstractValidator<DepartmentDTO>
    {
        public DepartmentValidator()
        {
            RuleFor(department => department.Name)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(100).WithMessage("Department name must not exceed 100 characters.");
        }
    }
}

