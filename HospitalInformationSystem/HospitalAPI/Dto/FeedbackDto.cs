using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class FeedbackDto
    {

        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public int PatientId { get; set; }
        public bool IsPublishable { get; set; }
        public bool IsAnonymous { get; set; }
        public FeedbackDto() { }

        public FeedbackDto(string content, bool isApproved, int patientId, bool isPublishable, bool isAnonymous) {
            this.Content = content;
            this.IsApproved = isApproved;
            this.PatientId = patientId;
            this.IsPublishable = isPublishable;
            this.IsAnonymous = isAnonymous;
        }
    }
}
