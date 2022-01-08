using System;

namespace HospitalClassLib.SharedModel
{
    public class VacationPeriod
    {
        public long ID { get; set; }

        public String VacationDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public VacationPeriod()
        {

        }

        public VacationPeriod(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public VacationPeriod(long id, String description, DateTime startVacation, DateTime endVacation)
        {
            this.ID = id;
            this.VacationDescription = description;
            this.StartTime = startVacation;
            this.EndTime = endVacation;
        }
    }
}
