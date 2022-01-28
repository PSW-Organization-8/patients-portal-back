
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.Schedule.Model
{
    public class SurgeryReport
    {
        public DateTime DateOfReport { get; set; }
        public String ReportID { get; set; }
        public String SurgeryName { get; set; }
        public String SurgeryDescription { get; set; }

        public SurgeryReport()
        {
            DateOfReport = DateTime.Today;
        }

        public SurgeryReport(Appointment surgery, String surgeryName, String surgeryDescription)
        {
            DateOfReport = DateTime.Today;
            SurgeryName = surgeryName;
            SurgeryDescription = surgeryDescription;
            //ReportID = surgery.AppointmentID;
        }

        

    }
}
