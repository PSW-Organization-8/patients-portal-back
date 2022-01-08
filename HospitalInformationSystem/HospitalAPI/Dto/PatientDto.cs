
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;

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
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Allergen> Allergens { get; set; }
        public int DoctorId { get; set; }
        public bool IsActivated { get; set; }
        public string Token { get; set; }
        public string Picture { get; set; }

        /*public PatientDto(string name, string lastName, string jmbg, string username, string password, string email, string phone, string country, string city, string address,
            DateTime dateOfBirth, ICollection<Allergen> allergens, int doctorId, bool isActivated, string token, string bloodType)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Country = country;
            City = city;
            Address = address;
            BloodType = bloodType;
            Allergens = allergens;
            DoctorId = doctorId;
            IsActivated = isActivated;
            Token = token;
        }*/

        public PatientDto(string name, string lastName, string jmbg, string username, string password, string email, string phone, string country, string city, string address,
            DateTime dateOfBirth, ICollection<Allergen> allergens, int doctorId, bool isActivated, string token, string bloodType, string picture)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Country = country;
            City = city;
            Address = address;
            BloodType = bloodType;
            Allergens = allergens;
            DoctorId = doctorId;
            IsActivated = isActivated;
            Token = token;
            Picture = picture;
        }

        public override bool Equals(object obj)
        {
            return obj is PatientDto dto &&
                   Name == dto.Name &&
                   LastName == dto.LastName &&
                   Jmbg == dto.Jmbg &&
                   Username == dto.Username &&
                   Password == dto.Password &&
                   Email == dto.Email &&
                   Phone == dto.Phone &&
                   DateOfBirth == dto.DateOfBirth &&
                   EqualityComparer<ICollection<Allergen>>.Default.Equals(Allergens, dto.Allergens) &&
                   DoctorId == dto.DoctorId &&
                   IsActivated == dto.IsActivated &&
                   Token == dto.Token;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}