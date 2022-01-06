using HospitalClassLib.RoomsAndEquipment.Model;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.Schedule.Model
{
    public class Hospitalization
    {
        public Patient Patient { get; set; }
        public Doctor LeadDoctor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SharedModel.Room Room { get; set; }
        public String HospitalizationID { get; set; }

        public Hospitalization()
        {
            HospitalizationID = DateTime.Now.ToString("ddMMyyyyHHmmss");
        }

        public Hospitalization(Patient patient, Doctor doctor, DateTime start, DateTime end, SharedModel.Room room)
        {
            Patient = patient;
            LeadDoctor = doctor;
            StartDate = start;
            EndDate = end;
            Room = room;
            HospitalizationID = DateTime.Now.ToString("ddMMyyyyHHmmss");
        }

        
        
        //TODO: move logic to DTO mapper
        public String GetStartDateString()
        {
            return StartDate.ToString("dd.MM.yyyy.");
        }

        //TODO: move logic to DTO mapper
        public String GetEndDateString()
        {
            return EndDate.ToString("dd.MM.yyyy.");
        }

    }
}
