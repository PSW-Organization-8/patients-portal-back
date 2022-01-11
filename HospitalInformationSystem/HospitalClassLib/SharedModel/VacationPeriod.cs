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
        public TimeRange TimeRange { get; set; }

        public VacationPeriod()
        {

        }

        public VacationPeriod(long id, String description, TimeRange tr)
        {
            this.ID = id;
            this.VacationDescription = description;
            this.TimeRange = tr;
        }
    }
}
