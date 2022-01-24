using HospitalClassLib.Events.Model;
using HospitalClassLib.Events.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public Event Create(Event @event)
        {
            return this.eventRepository.Create(@event);
        }

        public List<Event> GetAll()
        {
            return this.eventRepository.GetAll();
        }

        public EventData ButtonClicksByAge()
        {
            return this.eventRepository.ButtonClicksByAge();
        }

        public List<int> MostWantedSpecialization()
        {
            return this.eventRepository.MostWantedSpecialization();
        }

        public List<int> SuccessfulByTime()
        {
            return this.eventRepository.SuccessfulByTime();
        }

        public EventData BackNextClicks()
        {
            return this.eventRepository.BackNextClicks();
        }

        public List<DoctorEventStats> getDoctorEventStats()
        {
            return this.eventRepository.getDoctorEventStats();
        }

        public List<EventTypeData> getClickByMonth()
        {
            return this.eventRepository.getClicksByMonth();
        }
    }
}
