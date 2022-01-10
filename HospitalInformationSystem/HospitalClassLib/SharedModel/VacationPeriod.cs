using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClassLib.SharedModel
{
    public class VacationPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
