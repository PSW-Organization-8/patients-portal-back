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


    }
}
