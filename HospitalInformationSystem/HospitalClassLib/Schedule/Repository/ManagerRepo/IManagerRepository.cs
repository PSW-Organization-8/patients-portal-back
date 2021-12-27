using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.ManagerRepo
{
    public interface IManagerRepository
    {

        List<Manager> GetAll();
        Manager Get(int id);
        Manager Update(Manager manager);
        Manager Create(Manager manager);
        bool ExistsById(int id);
        bool Delete(int id);
    }
}
