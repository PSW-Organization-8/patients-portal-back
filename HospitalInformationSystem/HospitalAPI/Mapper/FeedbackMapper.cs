using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public class FeedbackMapper
    {
        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto, Patient patient)
        {
            return new Feedback(dto.Content, dto.IsApproved, DateTime.Now, patient, dto.IsPublishable, dto.IsAnonymous);
        }

        public static FeedbackDto FeedbackToFeedbackDto(Feedback feedback)
        {
            return new FeedbackDto(feedback.Content, feedback.FeedbackProperties.IsApproved, feedback.Patient.Id, feedback.FeedbackProperties.IsPublishable, 
                feedback.FeedbackProperties.IsAnonymous);
        }
    }
}
