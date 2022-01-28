using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Events.Model;
using HospitalClassLib.Events.Repository;
using HospitalClassLib.Events.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class EventTest
    {
        [Fact]
        public void Events_do_exist()
        {
            EventController controller = GetEventController();
            List<Event> retVal = controller.GetAll();
            retVal.Count.ShouldNotBe(0);
        }

        private EventController GetEventController()
        {
            MyDbContext dbContext = new MyDbContext();
            IEventRepository eventRepository = new EventRepository(dbContext);
            IEventService eventService = new EventService(eventRepository);
            EventController eventController = new EventController(eventService);

            return eventController;
        }
    }
}
