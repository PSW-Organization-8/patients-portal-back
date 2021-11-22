using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class PatientDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Allergen> Allergens { get; set; }
        public int DoctorId { get; set; }
        public bool IsActivated { get; set; }
        public string Token { get; set; }

        public PatientDto(string name, string lastName, string jmbg, string username, string password, string email, string phone, DateTime dateOfBirth,
            ICollection<Allergen> allergens, int doctorId, bool isActivated, string token)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Allergens = allergens;
            DoctorId = doctorId;
            IsActivated = isActivated;
            Token = token;
        }
    }
}
