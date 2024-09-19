using FluentValidation;
using MedicalStaff.Application.DTOs;


namespace MedicalStaff.Application.Validators
{
    public class NurseValidator : AbstractValidator<NurseDTO>
    {


        public NurseValidator()
        {
            RuleFor(nurse => nurse.Name)
                .NotEmpty().WithMessage("Nurse name is required.")
                .MaximumLength(100).WithMessage("Nurse name must not exceed 100 characters.");

            RuleFor(nurse => nurse.DepartmentName)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(50).WithMessage("Department name must not exceed 100 characters.");

        }
    }
}




       

