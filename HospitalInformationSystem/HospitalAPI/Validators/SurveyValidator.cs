using FluentValidation;
using HospitalAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class SurveyValidator : AbstractValidator<SurveyDto>
    {

        public SurveyValidator()
        {
            RuleFor(surveyDto => surveyDto.Questions).NotEmpty();
            RuleFor(surveyDto => surveyDto.Questions).NotNull();
            RuleFor(surveyDto => surveyDto.PatientId).NotNull();
            //RuleFor(surveyDto => surveyDto.Questions).Must(list => list.Count == 15);
            RuleForEach(surveyDto => surveyDto.Questions).SetValidator(new QuestionValidator());
        }

    }
}
