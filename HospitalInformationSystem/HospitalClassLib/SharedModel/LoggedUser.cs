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
        public Contact Contact { get; set; }
        public Address Address { get; set; }

        public LoggedUser(string name, string lastName, string jmbg, string username, string password, Contact contact, Address address)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Contact = contact;
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