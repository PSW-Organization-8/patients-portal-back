﻿using HospitalClassLib.Events.Model;
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

        public List<Tuple<int, int, int>> ButtonClicksByAge()
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
    }
}
