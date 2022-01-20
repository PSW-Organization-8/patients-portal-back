using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{
    public class MedicalReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }

        public string Prescription { get; set; }

        public string Anamnesis { get; set; }

        public MedicalReport() { }

        public MedicalReport(int appointment, string prescription, string anamnesis)
        {
            AppointmentId = appointment;
            Prescription = prescription;
            Anamnesis = anamnesis;
        }
    }
}
