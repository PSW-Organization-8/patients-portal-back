using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Repository.IRepository
{
   public  interface IEquipmentRepository : IGenericRepository<SharedModel.Equipment, long>
    {
        public SharedModel.Equipment GetByIdAndRoomId(long id, long roomId);
    }
}
