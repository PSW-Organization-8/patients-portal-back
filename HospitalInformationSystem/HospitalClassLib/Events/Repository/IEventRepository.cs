using HospitalClassLib.Events.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Repository
{
    public interface IEventRepository : IGenericRepository<Event, long>
    {
        EventData ButtonClicksByAge();
        List<int> MostWantedSpecialization();
        List<int> SuccessfulByTime();
        EventData BackNextClicks();
        List<DoctorEventStats> getDoctorEventStats();
    }
}
