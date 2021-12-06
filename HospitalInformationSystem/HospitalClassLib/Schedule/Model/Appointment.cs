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
        //public int Duration { get; set; }
        public AppointmentType Type { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        //public Room Room { get; set; }
        //public DateTime InitialTime { get; set; }
        
    
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

        }

        public Appointment(DateTime dateTime, Doctor doctor, Patient patient)
        {
            this.StartTime = dateTime;
            this.Doctor = doctor;
            this.Patient = patient;
        }



        /*public bool EqualDate(DateTime date)
        {
            return this.StartTime == date;
        }

        public DateTime GetEndTime()
        {
            return StartTime.AddMinutes(Duration);
        }

        public bool GetIfPast()
        {
            return (GetEndTime() < DateTime.Now);
        }

        public String GetAppointmentDate() 
        { 
            return StartTime.ToString("dd.MM.yyyy."); 
        }

        public String GetAppointmentTime()
        {
            return StartTime.ToString("HH:mm");
        }

        

        private static string GenerateID()
        {
            return DateTime.Now.ToString("yyMMddhhmmssffffff");
        }

        public bool GetIfCurrent()
        {
            return (StartTime <= DateTime.Now && GetEndTime() >= DateTime.Now);
        }

        

        //TODO: move logic to dto mapper
        public String GetPatientName()
        {
            return Patient.FullName;
        }

        //TODO: move logic to dto mapper
        public String GetDoctorName()
        {
            return Doctor.FullName;
        }

        //TODO: move logic to mapper
        public String AppointmentFullInfo
        {
            get => GetDoctorName() + ", " + GetAppointmentTime() + " " + GetAppointmentDate();
        }

        public bool SameStartTime(DateTime startTime)
        {
            return this.StartTime == startTime;
        }
        */

    }
}