using HospitalClassLib.RoomsAndEquipment.Model;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClassLib.Schedule.Model
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public AppointmentType Type { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public AppointmentState State {get; set; }
    
        public Appointment() { }

        public Appointment(int id, DateTime startTime, AppointmentType type, Doctor doctor, Patient patient)
        {
            this.Id = id;
            this.StartTime = startTime;
            this.Type = type;
            this.Doctor = doctor;
            this.DoctorId = doctor.Id;
            this.Patient = patient;
            this.PatientId = patient.Id;
            this.State = AppointmentState.pending;
        }
    }
}