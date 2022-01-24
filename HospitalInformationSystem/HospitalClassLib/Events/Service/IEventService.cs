using HospitalClassLib.Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Service
{
    public interface IEventService
    {
        List<Event> GetAll();
        Event Create(Event @event);
        EventData ButtonClicksByAge();
        List<int> MostWantedSpecialization();
        List<int> SuccessfulByTime();
        EventData BackNextClicks();
        List<DoctorEventStats> getDoctorEventStats();
        List<EventTypeData> getClickByMonth();
    }
}
