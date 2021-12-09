using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLib.MedicalRecords.Model
{
    public class Medication
    {
        public Medication(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public Medication() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MedicineID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
