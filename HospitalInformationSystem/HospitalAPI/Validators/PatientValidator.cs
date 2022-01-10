using FluentValidation;
using HospitalClassLib.Schedule.Model;

namespace HospitalAPI.Validators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient).NotNull();
            RuleFor(patient => patient.Name).Matches("^[a-zA-Z]+$").WithMessage("Name can contains only letters");
            RuleFor(patient => patient.LastName).Matches("^[a-zA-Z]+$").WithMessage("Last name can contains only letters");
            RuleFor(patient => patient.Jmbg).Matches("[0-9]{13}").WithMessage("Jmbg must contain 13 numerics and cannot have any other characters");
        }
    }
}