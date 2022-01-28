using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class FreeDoctorDto
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FreeDoctorDto(int doctorId, string firstName, string lastName) {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
