
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace HospitalClassLib.SharedModel
{
    public class Receipt
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReceiptID { get; set; }
        public string MedicineName { get; set; }
        public int Amount { get; set; }
        public string Diagnosis { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }

        public Receipt()
        {
            Date = DateTime.Today;
        }

        public Receipt(int doctor, int patient, string medicineName, int amount, string diagnosis)
        {
            DoctorId = doctor;
            PatientId = patient;
            MedicineName = medicineName;
            Amount = amount;
            Diagnosis = diagnosis;
            Date = DateTime.Today;

        }

        

    }
}
