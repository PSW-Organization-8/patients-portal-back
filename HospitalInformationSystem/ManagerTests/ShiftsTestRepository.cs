using HospitalClassLib.SharedModel;
using HospitalClassLib.Shift.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTests
{
    class ShiftsTestRepository : IShiftRepository
    {
        private Dictionary<long, Shift> allShifts = new Dictionary<long, Shift>();

        public ShiftsTestRepository()
        {
            Shift shift1 = new Shift { ID = 1, ShiftType = "Morning shift", ShiftStart = "7:00", ShiftEnd = "13:00" };
            Shift shift2 = new Shift { ID = 2, ShiftType = "Afternoon shift", ShiftStart = "13:00", ShiftEnd = "20:00" };
            Shift shift3 = new Shift { ID = 3, ShiftType = "Night shift", ShiftStart = "20:00", ShiftEnd = "7:00" };

            allShifts.Add(1, shift1);
            allShifts.Add(2, shift2);
            allShifts.Add(3, shift3);
        }

        public Shift Create(Shift t)
        {
            allShifts.Add(t.ID, t);
            return allShifts[t.ID];
        }

        public bool Delete(long id)
        {
            return allShifts.Remove(id);
        }

        public bool ExistsById(long id)
        {
            return allShifts.ContainsKey(id);
        }

        public Shift Get(long id)
        {
            return allShifts[id];
        }

        public List<Shift> GetAll()
        {
            return allShifts.Values.ToList();
        }

        public Shift Update(Shift t)
        {
            allShifts[t.ID] = t;
            return allShifts[t.ID];
        }
    }
}
