using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{

    public class Patient : LoggedUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsBanned { get; set; }
        public string Lbo { get; set; }
        public bool Guest { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Allergen> Allergens { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public bool IsActivated { get; set; }
        public int Token { get; internal set; }

        public Patient() { }

        public Patient(string name, string lastName, string jmbg, string username, string password, string email, string phone, bool isBanned, string lbo, bool guest, 
            DateTime dateOfBirth, ICollection<Allergen> allergens, Doctor doctor, bool isActivated, int token) {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            IsBanned = isBanned;
            Lbo = lbo;
            Guest = guest;
            DateOfBirth = dateOfBirth;
            Allergens = allergens;
            Doctor = doctor;
            DoctorId = 1;
            Feedbacks = new List<Feedback>();
            IsActivated = isActivated;
            Token = token;
        }
    }
}
