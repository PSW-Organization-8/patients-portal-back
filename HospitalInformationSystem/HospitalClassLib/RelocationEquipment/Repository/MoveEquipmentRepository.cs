using HospitalClassLib.RelocationEquipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.RelocationEquipment.Repository
{
    public class MoveEquipmentRepository : AbstractSqlRepository<MoveEquipment, long>, IMoveEquipmentRepository
    {
        public MoveEquipmentRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(MoveEquipment entity)
        {
            return entity.ID;
        }

        public  List<MoveEquipment> GetAll()
        {
            return context.MoveEquipments.Include(x => x.Equipment).ToList();
        }

        public  MoveEquipment Get(long id)
        {
            return context.MoveEquipments.Include(x => x.Equipment).Where(x => x.ID == id).SingleOrDefault();
        }

    }
}
