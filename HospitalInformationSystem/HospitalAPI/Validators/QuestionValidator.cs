using FluentValidation;
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(question => question.Value).NotNull();
            RuleFor(question => question.Value).Must(value => value >= 1 && value <= 5);
        }
    }
}
