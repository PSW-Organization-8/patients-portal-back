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


        [Fact]
        public void Button_clicks_by_age()
        {
            EventController controller = GetEventController();
            EventData retVal = controller.BackNextClicks();
            retVal.ShouldNotBe(null);
        }

        [Fact]
        public void Most_wanted_specialization()
        {
            EventController controller = GetEventController();
            List<int> retVal = controller.MostWantedSpecialization();
            retVal.Count.ShouldNotBe(0);
        }

        [Fact]
        public void Successful_by_time()
        {
            EventController controller = GetEventController();
            List<int> retVal = controller.SuccessfulByTime();
            retVal.Count.ShouldNotBe(0);
        }

        [Fact]
        public void Back_next_clicks()
        {
            EventController controller = GetEventController();
            EventData retVal = controller.BackNextClicks();
            retVal.ShouldNotBe(null);
        }
    }
}
