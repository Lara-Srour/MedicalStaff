using FluentValidation;
using MedicalStaff.Application.DTOs;

namespace MedicalStaff.Application.Validators
{
    public class DoctorValidator : AbstractValidator<DoctorDTO>
    {
        public DoctorValidator()
        {
            RuleFor(doctor => doctor.Name)
                .NotEmpty().WithMessage("Doctor name is required.")
                .MaximumLength(100).WithMessage("Doctor name must not exceed 100 characters.");

            RuleFor(doctor => doctor.Specialty)
                .NotEmpty().WithMessage("Specialty is required.")
                .MaximumLength(50).WithMessage("Specialty must not exceed 100 characters.");
        }
    }
}