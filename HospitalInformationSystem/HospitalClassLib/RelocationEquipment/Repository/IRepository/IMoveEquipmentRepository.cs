using HospitalClassLib.SharedModel;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.RelocationEquipment.Repository.IRepository
{
    public interface IMoveEquipmentRepository : IGenericRepository<MoveEquipment, long>
    {
    }
}
