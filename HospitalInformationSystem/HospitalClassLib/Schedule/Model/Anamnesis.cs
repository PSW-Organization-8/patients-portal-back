
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.HospitalClassLib.Schedule.Model
{
    public class Anamnesis
    {
        

        public String MainIssues { get; set; }
        public String CurrentAnamnesis { get; set; }
        public String GeneralOccurrences { get; set; }
        public String RespiratorySystem { get; set; }
        public String CardioSystem { get; set; }
        public String DigestiveSystem { get; set; }
        public String UroGenitalSystem { get; set; }
        public String LocomotorSystem { get; set; }
        public String NervousSystem { get; set; }
        public String PastDiseases { get; set; }
        public String FamilyData { get; set; }
        public String SocioEpiData { get; set; }
        public DateTime AnamnesisDate { get; set; }
        public String AnamnesisID { get; set; }
        private bool serialize;

        
        public Appointment AnamnesisAppointment { get; set; }
        public bool Serialize { get => serialize; set => serialize = value; }

        public Anamnesis()
        {
            AnamnesisDate = DateTime.Today;
            serialize = true;
        }

        public Anamnesis(Appointment appointment, String mainIssues, String currentAnamnesis, String generalOccurrences, String respiratorySystem, String cardioSystem,
            String digestiveSystem, String uroGenitalSystem, String locomotorSystem, String nervousSystem, String pastDiseases, String familyData, String socioEpiData)
        {
            AnamnesisAppointment = appointment;
            AnamnesisDate = DateTime.Today;

            MainIssues = mainIssues;
            CurrentAnamnesis = currentAnamnesis;
            GeneralOccurrences = generalOccurrences;
            //AnamnesisID = appointment.AppointmentID;
            RespiratorySystem = respiratorySystem;
            CardioSystem = cardioSystem;
            DigestiveSystem = digestiveSystem;
            UroGenitalSystem = uroGenitalSystem;
            LocomotorSystem = locomotorSystem;
            NervousSystem = nervousSystem;
            PastDiseases = pastDiseases;
            FamilyData = familyData;
            SocioEpiData = socioEpiData;
            serialize = true;

            
        }

        public Anamnesis(Anamnesis anamnesis)
        {


            AnamnesisAppointment = anamnesis.AnamnesisAppointment;
            AnamnesisDate = anamnesis.AnamnesisDate;

            MainIssues = anamnesis.MainIssues;
            CurrentAnamnesis = anamnesis.CurrentAnamnesis;
            GeneralOccurrences = anamnesis.GeneralOccurrences;
            AnamnesisID = anamnesis.AnamnesisID;
            RespiratorySystem = anamnesis.RespiratorySystem;
            CardioSystem = anamnesis.CardioSystem;
            DigestiveSystem = anamnesis.DigestiveSystem;
            UroGenitalSystem = anamnesis.UroGenitalSystem;
            LocomotorSystem = anamnesis.LocomotorSystem;
            NervousSystem = anamnesis.NervousSystem;
            PastDiseases = anamnesis.PastDiseases;
            FamilyData = anamnesis.FamilyData;
            SocioEpiData = anamnesis.SocioEpiData;
            serialize = true;
        }
    }
}
