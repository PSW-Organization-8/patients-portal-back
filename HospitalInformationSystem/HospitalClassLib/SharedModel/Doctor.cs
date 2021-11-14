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
    }
}