using HospitalClassLib.Shift.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Shift.Service
{
    public class ShiftService
    {
        private readonly IShiftRepository shiftRepository;


        public ShiftService(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;

        }

        public List<SharedModel.Shift> GetAllShifts()
        {
            return shiftRepository.GetAll();
        }

        public void CreateAllShifts(List<SharedModel.Shift> allNewShifts)
        {
            foreach (SharedModel.Shift newShifts in allNewShifts)
            {
                CreateShifts(newShifts);
            }
        }

        public SharedModel.Shift GetShiftByID(long ID)
        {
            List<SharedModel.Shift> allShift = GetAllShifts();
            foreach (SharedModel.Shift shift in allShift)
            {
                if (shift.ID == ID)
                    return shift;
            }

            return null;
        }

        public SharedModel.Shift CreateShifts(SharedModel.Shift newShifts)
        {
            return shiftRepository.Create(newShifts);
        }
    }
}
