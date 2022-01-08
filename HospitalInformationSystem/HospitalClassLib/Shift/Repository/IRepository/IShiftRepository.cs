using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Shift.Repository.IRepository
{
    public interface IShiftRepository : IGenericRepository<SharedModel.Shift, long>
    {
    }
}
