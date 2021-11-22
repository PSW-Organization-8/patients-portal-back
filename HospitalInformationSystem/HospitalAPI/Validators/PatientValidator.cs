
using FluentValidation;
using FluentValidation.Results;
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient).NotNull();
        }
    }
}
