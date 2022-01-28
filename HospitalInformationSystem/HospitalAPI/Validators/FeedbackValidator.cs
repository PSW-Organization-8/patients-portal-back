using FluentValidation;
using FluentValidation.Results;
using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class FeedbackValidator : AbstractValidator<FeedbackDto>
    {
        public FeedbackValidator()
        {
            RuleFor(feedbackDto => feedbackDto.Content).NotEmpty();
        }
    }
}
