using HospitalClassLib.SharedModel;
using HospitalClassLib.Shift.Repository.IRepository;
using HospitalClassLib.Shift.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace ManagerTests
{
    public class ShiftTests
    {
        private IShiftRepository shiftRepository;
        private ShiftService shiftService;

        public ShiftTests() { }

        [Fact]
        public void Get_all_shifts_test()
        {
            PrepareShiftsTestRepository();
            List<Shift> shifts = shiftService.GetAllShifts();

            shifts.Count.ShouldBe(3);
        }

        [Fact]
        public void Get_shift_by_ID_test()
        {
            PrepareShiftsTestRepository();

            Shift shift = shiftService.GetShiftByID(2);
            shift.ID.ShouldBe(2);
        }

        [Fact]
        public void Create_shift_test()
        {
            PrepareShiftsTestRepository();

            Shift shift = new Shift { ID = 4, ShiftType = "Added shift", ShiftStart = "20:00", ShiftEnd = "7:00" };

            shiftService.CreateShifts(shift);

            List<Shift> shifts = shiftService.GetAllShifts();
            shifts.Count.ShouldBe(4);
        }

        [Fact]
        public void Edit_shift_test()
        {
            PrepareShiftsTestRepository();

            Shift shiftToEdit = shiftService.GetAllShifts()[2];
            shiftToEdit.ShiftType = "Edited shift";

            shiftService.EditShifts(shiftToEdit);

            List<Shift> shifts = shiftService.GetAllShifts();
            Shift shift = shiftService.GetShiftByID(shiftToEdit.ID);
            shift.ShiftType.ShouldBe("Edited shift");
        }

        [Fact]
        public void Create_all_shifts()
        {
            PrepareShiftsTestRepository();

            Shift shift1 = new Shift { ID = 4, ShiftType = "Added shift 1", ShiftStart = "20:00", ShiftEnd = "7:00" };
            Shift shift2 = new Shift { ID = 5, ShiftType = "Added shift 2", ShiftStart = "20:00", ShiftEnd = "7:00" };

            List<Shift> shiftsToAdd = new List<Shift>() { shift1, shift2 };

            shiftService.CreateAllShifts(shiftsToAdd);

            List<Shift> shifts = shiftService.GetAllShifts();
            shifts.Count.ShouldBe(5);
        }

        private void PrepareShiftsTestRepository()
        {
            shiftRepository = new ShiftsTestRepository();
            shiftService = new ShiftService(shiftRepository);
        }
    }
}
