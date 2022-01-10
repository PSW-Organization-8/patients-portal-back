// File:    Lekar.cs
// Author:  paracelsus
// Created: Monday, March 22, 2021 7:32:13 PM
// Purpose: Definition of Class Lekar

using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClassLib.SharedModel
{
    public class Doctor : LoggedUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Specialization DoctorSpecialization { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual Shift DoctorShift { get; set; }

        public long DoctorShiftID { get; set; }

        public virtual VacationPeriod Vacation { get; set; }

        public long VacationID { get; set; }

        public Doctor() { }

        public Doctor(int id, Specialization doctorSpecialization, ICollection<Patient> patients, ICollection<Appointment> appointments, Shift doctorShift, long doctorShiftID, VacationPeriod vacation, long vacationID)
        {
            Id = id;
            DoctorSpecialization = doctorSpecialization;
            Patients = patients;
            Appointments = appointments;
            DoctorShift = doctorShift;
            DoctorShiftID = doctorShift.ID;
            Vacation = vacation;
            VacationID = vacation.ID;

        }

        public Doctor(int id, string name, string lastname, string jmbg, string username, string password, Specialization doctorSpecialization, ICollection<Patient> patients, ICollection<Appointment> appointments, long doctorShiftID, long vacationID)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            DoctorSpecialization = doctorSpecialization;
            Patients = patients;
            Appointments = appointments;
            DoctorShiftID = doctorShiftID;
            VacationID = vacationID;
        }

        
    }
}