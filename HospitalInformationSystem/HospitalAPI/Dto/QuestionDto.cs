using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public float AvgValue { get; set; }

        public QuestionDto() {}
        public QuestionDto(int id, float avgValue)
        {
            this.Id = id;
            this.AvgValue = avgValue;
        }
    }
}
