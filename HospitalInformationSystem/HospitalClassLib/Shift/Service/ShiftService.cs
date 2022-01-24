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

        public List<SharedModel.Shift> GetAllNotDeletedShifts()
        {
            List<SharedModel.Shift> allShift = GetAllShifts();
            foreach (SharedModel.Shift shift in allShift)
            {
                if (shift.Deleted == false)
                { return allShift; }
               
            }
            return null;
        }

        public SharedModel.Shift DeleteThisShift(SharedModel.Shift shiftForDelete, long ID)
        {
            List<SharedModel.Shift> allShift = GetAllNotDeletedShifts();
            foreach (SharedModel.Shift shift in allShift)
            {
                if (shift.ID== ID)
                {
                     _= shift.Deleted == true;
                    return shiftRepository.Update(shiftForDelete);
                }
            }

            return null;

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

        public bool DeleteShift(long ID)
        {
            List<SharedModel.Shift> allShift = GetAllShifts();
            foreach (SharedModel.Shift shift in allShift)
            {
                if (shift.ID == ID)
                    return shiftRepository.Delete(ID);
            }

            return false;
        }

        public SharedModel.Shift CreateShifts(SharedModel.Shift newShifts)
        {
            return shiftRepository.Create(newShifts);
        }

        public SharedModel.Shift EditShifts(SharedModel.Shift newShifts)
        {
            return shiftRepository.Update(newShifts);
        }
    }
}
