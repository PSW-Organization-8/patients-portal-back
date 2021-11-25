// File:    UlogovanKorisnik.cs
// Author:  paracelsus
// Created: Monday, March 22, 2021 6:37:39 PM
// Purpose: Definition of Class UlogovanKorisnik

using System;

namespace HospitalClassLib.SharedModel
{
    public class LoggedUser
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

        public LoggedUser(string name, string lastName, string jmbg, string username, string password, string email, string phone, string country, string city, string address)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            Country = country;
            City = city;
            Address = address;
        }

        public LoggedUser()
        {

        }

        public bool EqualJmbg(String Jmbg)
        {
            return this.Jmbg == Jmbg;
        }

        public String FullName { get => (Name + " " + LastName); }
    }
}