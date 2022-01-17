using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClassLib.Schedule.Model
{

    public class Patient : LoggedUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Allergen> Allergens { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string Token { get; internal set; }
        public string Picture { get; set; }
        public PatientAccountStatus PatientAccountStatus {get; set;}
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Patient() {
        }

        public Patient(string name, string lastName, string jmbg, string username, string password, string email, string phone, string country, string city, string address,
            bool isBanned, DateTime dateOfBirth, ICollection<Allergen> allergens, Doctor doctor, bool isActivated, string token, BloodType bloodType)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Contact = new Contact(email, phone);
            DateOfBirth = dateOfBirth;
            Address = new Address(country, city, address);
            BloodType = bloodType;
            Allergens = allergens;
            Doctor = doctor;
            DoctorId = doctor.Id;
            Feedbacks = new List<Feedback>();
            Token = token;
            PatientAccountStatus = new PatientAccountStatus(isBanned, isActivated);
        }

        public Patient(string name, string lastName, string jmbg, string username, string password, string email, string phone, string country, string city, string address,
            DateTime dateOfBirth, ICollection<Allergen> allergens, int doctorId, bool isActivated, string token, string bloodType)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Contact = new Contact(email, phone);
            DateOfBirth = dateOfBirth;
            Address = new Address(country, city, address);
            BloodType = BloodType.ABn;
            Allergens = allergens;
            DoctorId = doctorId;
            Token = token;
            PatientAccountStatus = new PatientAccountStatus(false, isActivated);
        }

        public Patient(string name, string lastName, string jmbg, string username, string password, string email, string phone, string country, string city, string address,
            bool isBanned, DateTime dateOfBirth, ICollection<Allergen> allergens, Doctor doctor, bool isActivated, string token, BloodType bloodType, string picture)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Contact = new Contact(email, phone);
            DateOfBirth = dateOfBirth;
            Address = new Address(country, city, address);
            BloodType = bloodType;
            Allergens = allergens;
            Doctor = doctor;
            DoctorId = doctor.Id;
            Feedbacks = new List<Feedback>();
            Token = token;
            Picture = picture;
            PatientAccountStatus = new PatientAccountStatus(isBanned, isActivated);
        }

        public override bool Equals(object obj)
        {
            return obj is Patient patient &&
                   Name == patient.Name &&
                   LastName == patient.LastName &&
                   Jmbg == patient.Jmbg;
        }
    }
}