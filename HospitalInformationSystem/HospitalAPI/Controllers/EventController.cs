using HospitalClassLib.Events.Model;
using HospitalClassLib.Events.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public List<Event> GetAll()
        {
            return eventService.GetAll();
        }

        [HttpPost]
        public Event Create(Event @event)
        {
            return eventService.Create(@event);
        }

        [HttpGet]
        [Route("buttonClicks")]
        [Authorize]
        public EventData ButtonClicksByAge()
        {
            return eventService.ButtonClicksByAge();
        }

        [HttpGet]
        [Route("specialization")]
        [Authorize]
        public List<int> MostWantedSpecialization()
        {
            return eventService.MostWantedSpecialization();
        }

        [HttpGet]
        [Route("successfulByTime")]
        [Authorize]
        public List<int> SuccessfulByTime()
        {
            return eventService.SuccessfulByTime();
        }
        
        [HttpGet]
        [Route("backNextClicks")]
        [Authorize]
        public EventData BackNextClicks()
        {
            return eventService.BackNextClicks();
        }

        [HttpGet]
        [Route("doctorStats")]
        public List<DoctorEventStats> getDoctorEventStats()
        {
            return eventService.getDoctorEventStats();
        }
    }
}
