
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.SharedModel
{
    public class Referral
    {
        private static int refferalValidDays = 7;

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime RefferalDate { get; set; }
        public String RefferalKey { get; set; }

        public Referral()
        {
            RefferalKey = DateTime.Now.ToString("HHmmssDDMMyy");
        }

        public Referral(Doctor doctor, Patient patient)
        {
            RefferalDate = DateTime.Today;
            Doctor = doctor;
            Patient = patient;
            RefferalKey = DateTime.Now.ToString("HHmmssDDMMyy");
        }

        

        public Boolean IsRefferalValid()
        {
            DateTime today = DateTime.Today;
            DateTime endValidDay = RefferalDate.AddDays(refferalValidDays);

            if (today <= endValidDay)
            {
                return true;
            }

            return false;

        }


    }
}
