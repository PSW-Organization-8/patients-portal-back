using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class SurveyDto
    {
        public int PatientId { get; set; }
        public List<Question> Questions { get; set; }

        public SurveyDto() { }

        public SurveyDto(int patientId, List<Question> questions) 
        {
            this.PatientId = patientId;
            this.Questions = questions;
        }



    }
}
