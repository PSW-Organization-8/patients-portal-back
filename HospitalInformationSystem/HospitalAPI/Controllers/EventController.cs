using HospitalClassLib.Events.Model;
using HospitalClassLib.Events.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

    }
}
