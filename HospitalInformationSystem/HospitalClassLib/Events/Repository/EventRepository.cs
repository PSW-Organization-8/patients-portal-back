using HospitalClassLib.Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Repository
{
    public class EventRepository : AbstractSqlRepository<Event, long>, IEventRepository
    {
        private MyDbContext dbContext;

        public EventRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext; 
        }

        public EventData BackNextClicks()
        {
            return new EventData(
                dbContext.Events.Where(x => x.EventClass.Equals(EventClass.Next)).GroupBy(x => x.OptionalEventNumInfo).OrderBy(x => x.Key).Select(x => x.Count()).ToList(),
                dbContext.Events.Where(x => x.EventClass.Equals(EventClass.Back)).GroupBy(x => x.OptionalEventNumInfo).OrderBy(x => x.Key).Select(x => x.Count()).ToList());
        }

        public EventData ButtonClicksByAge()
        {
            List<int> minors = dbContext.Events.Join(dbContext.Patients.Where(x => DateTime.Now.Year - x.DateOfBirth.Year <= 18),
                                            x => x.UserId,
                                            y => y.Username,
                                            (x, y) => x).GroupBy(x => x.EventClass).OrderBy(x => x.Key).Select(x => x.Count()).ToList();

            List<int> youngAdults = dbContext.Events.Join(dbContext.Patients.Where(x => DateTime.Now.Year - x.DateOfBirth.Year <= 32 && DateTime.Now.Year - x.DateOfBirth.Year > 18),
                                            x => x.UserId,
                                            y => y.Username,
                                            (x, y) => x).GroupBy(x => x.EventClass).OrderBy(x => x.Key).Select(x => x.Count() / dbContext.Patients.Where(x => DateTime.Now.Year - x.DateOfBirth.Year <= 32 && DateTime.Now.Year - x.DateOfBirth.Year > 18).Count()).ToList();

            List<int> adults = dbContext.Events.Join(dbContext.Patients.Where(x => DateTime.Now.Year - x.DateOfBirth.Year <= 45 && DateTime.Now.Year - x.DateOfBirth.Year > 32),
                                            x => x.UserId,
                                            y => y.Username,
                                            (x, y) => x).GroupBy(x => x.EventClass).OrderBy(x => x.Key).Select(x => x.Count()).ToList();

            List<int> seniors = dbContext.Events.Join(dbContext.Patients.Where(x => DateTime.Now.Year - x.DateOfBirth.Year <= 65 && DateTime.Now.Year - x.DateOfBirth.Year > 45),
                                            x => x.UserId,
                                            y => y.Username,
                                            (x, y) => x).GroupBy(x => x.EventClass).OrderBy(x => x.Key).Select(x => x.Count()).ToList();

            List<int> veterans = dbContext.Events.Join(dbContext.Patients.Where(x => DateTime.Now.Year - x.DateOfBirth.Year > 65),
                                            x => x.UserId,
                                            y => y.Username,
                                            (x, y) => x).GroupBy(x => x.EventClass).OrderBy(x => x.Key).Select(x => x.Count()).ToList();

            return new EventData(minors, youngAdults, adults, seniors, veterans);
        }

        public List<DoctorEventStats> getDoctorEventStats()
        {
            List<string> doctorsUsername = dbContext.Doctors.OrderBy(d => d.Id).Select(d => d.Username).ToList();
            List<string> doctorsSpecialization= dbContext.Doctors.OrderBy(d => d.Id).Select(d => d.DoctorSpecialization.ToString()).ToList();
            List<string> doctorsName= dbContext.Doctors.OrderBy(d => d.Id).Select(d => d.FullName).ToList();
            return dbContext.Events.Where(x => x.DoctorUsername != null).GroupBy(x => x.DoctorUsername).OrderBy(x => x.Key).Select(x => new DoctorEventStats(
                                                doctorsName[doctorsUsername.IndexOf(x.Key)],
                                                doctorsSpecialization[doctorsUsername.IndexOf(x.Key)],
                                                dbContext.Events.Count(e => e.DoctorUsername == x.Key && e.EventClass == EventClass.DoctorInput),
                                                dbContext.Events.Count(e => e.DoctorUsername == x.Key && e.EventClass == EventClass.Schedule),
                                                dbContext.Events.Select(e => e.UserId).Distinct().Count())).ToList();
        }

        public List<int> MostWantedSpecialization()
        {
            return dbContext.Events.GroupBy(x => x.DoctorSpecialization).OrderBy(x => x.Key).Select(x => x.Count()).ToList();
        }

        public List<int> SuccessfulByTime()
        {
            List<int> list = new List<int>();
            int byYear1 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddYears(-1) && x.TimeStamp <= DateTime.Now).Count();
            int byYear2 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddYears(-2) && x.TimeStamp <= DateTime.Now.AddYears(-1)).Count();
            int byYear3 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddYears(-3) && x.TimeStamp <= DateTime.Now.AddYears(-2)).Count();

            int byMonth1 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddMonths(-1) && x.TimeStamp <= DateTime.Now).Count();
            int byMonth2= dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddMonths(-2) && x.TimeStamp <= DateTime.Now.AddMonths(-1)).Count();
            int byMonth3 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddMonths(-3) && x.TimeStamp <= DateTime.Now.AddMonths(-2)).Count();

            int byWeek1 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddDays(-7) && x.TimeStamp <= DateTime.Now).Count();
            int byWeek2 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddDays(-14) && x.TimeStamp <= DateTime.Now.AddDays(-7)).Count();
            int byWeek3 = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddDays(-21) && x.TimeStamp <= DateTime.Now.AddDays(-14)).Count();
            
            list.Add(byYear1);
            list.Add(byYear2);
            list.Add(byYear3);
            list.Add(byMonth1);
            list.Add(byMonth2);
            list.Add(byMonth3);
            list.Add(byWeek1);
            list.Add(byWeek2);
            list.Add(byWeek3);
            return list; 
        }

        protected override long GetId(Event entity)
        {
            return entity.Id;
        }
    }
}
