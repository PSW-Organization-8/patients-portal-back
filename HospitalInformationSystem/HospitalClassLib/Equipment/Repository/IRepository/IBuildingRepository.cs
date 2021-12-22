using HospitalClassLib.SharedModel;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Repository.IRepository
{
    public interface IBuildingRepository : IGenericRepository<Building, long>
    {
    }
}
