using FluentValidation;
using MedicalStaff.Application.DTOs;

namespace MedicalStaff.Application.Validators
{
    public class PatientValidator : AbstractValidator<PatientDTO>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient.Name)
                .NotEmpty().WithMessage("Patient name is required.")
                .MaximumLength(100).WithMessage("Patient name must not exceed 100 characters.");

            RuleFor(patient => patient.RoomNumber)
                .GreaterThan(0).WithMessage("Room number must be greater than zero.");
        }
    }
}