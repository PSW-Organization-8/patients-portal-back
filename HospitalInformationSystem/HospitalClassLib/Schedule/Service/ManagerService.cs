using HospitalClassLib.Schedule.Repository.ManagerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class ManagerService
    {

        private readonly IManagerRepository managerRepository;
        public ManagerService(IManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public object GetByUsername(string username)
        {
            return managerRepository.GetByUsername(username);
        }
    }
}
