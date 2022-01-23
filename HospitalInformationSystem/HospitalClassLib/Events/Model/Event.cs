using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Model
{

    [Table("Event", Schema = "Events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Store user's id (as a string), username, or email address
        public String UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public ApplicationName EventApplicationName { get; set; }
        public EventClass EventClass { get; set; }
        public Double OptionalEventNumInfo { get; set; }
        public DateTime ChoosenTime { get; set; }
        public Specialization DoctorSpecialization { get; set; }
        public String DoctorUsername{ get; set; }

        public Event()
        {
            this.TimeStamp = DateTime.Now;
            this.EventClass = EventClass.Other;
            this.EventApplicationName = ApplicationName.PatientsPortal;
        }

        public Event(string userId, ApplicationName eventApplicationName, EventClass eventClass, double optionalEventNumInfo, Specialization doctorSpecialization, DateTime choosenTime, string doctorUsername)
        {
            TimeStamp = DateTime.Now;
            UserId = userId;
            EventApplicationName = eventApplicationName;
            EventClass = eventClass;
            OptionalEventNumInfo = optionalEventNumInfo;
            ChoosenTime = choosenTime;
            DoctorSpecialization = doctorSpecialization;
            DoctorUsername = doctorUsername;
        }

        public Event(long id, string userId, ApplicationName eventApplicationName, EventClass eventClass)
        {
            Id = id;
            TimeStamp = DateTime.Now;
            UserId = userId;
            EventApplicationName = eventApplicationName;
            EventClass = eventClass;
        }

        public Event(long id, string username, EventClass eventClass, int optionalEventNumInfo)
        {
            Id = id;
            UserId = username;
            EventClass = eventClass;
            OptionalEventNumInfo = optionalEventNumInfo;
        }
    }}
