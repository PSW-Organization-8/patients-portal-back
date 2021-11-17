using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Survey() 
        { }
        public Survey(int id, Patient patient) 
        {
            this.Id = id;
            this.Patient = patient;
            this.PatientId = patient.Id;
        }

        public Survey(Patient patient) 
        {
            this.Patient = patient;
            this.PatientId = patient.Id;
        }
    }
}
