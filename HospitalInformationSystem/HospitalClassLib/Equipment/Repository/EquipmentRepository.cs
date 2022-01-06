using HospitalClassLib.Equipment.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLib.SharedModel;
using Microsoft.EntityFrameworkCore;
using HospitalClassLib;

namespace HospitalClassLib.Equipment.Repository
{
    public class EquipmentRepository : AbstractSqlRepository<SharedModel.Equipment, long>, IEquipmentRepository
    {
        public EquipmentRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(SharedModel.Equipment entity)
        {
            return entity.ID;
        }

        public  List<SharedModel.Equipment> GetAll()
        {
            return context.Equipments.Include(x => x.Room).ToList();
        }

        public  SharedModel.Equipment Get(long id) 
        {
            return context.Equipments.Include(x => x.Room).Where(x => x.ID == id).SingleOrDefault();
        }

        public SharedModel.Equipment GetByIdAndRoomId(long id, long roomId)
        {
            return context.Equipments.Include(x => x.Room).Where(x => x.ID == id && x.Room.ID == roomId).SingleOrDefault();
        }
    }

}
