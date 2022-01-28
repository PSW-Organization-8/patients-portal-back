using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class ValidatorTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Validator_id(int id, bool expected)
        {
            var validator = new IdValidator();

            var result = validator.CheckId(id);

            Assert.Equal(expected, result);

        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 10, true },
            new object[] { -1, false },
            new object[] { null, false },
            new object[] { 0, false }
        };

        [Theory]
        [MemberData(nameof(Data2))]
        public void Advanced_appointment_validator(AdvancedAppointmentDto advancedAppointmentDto, bool expected)
        {
            AdvancedAppointmentValidator validator = new AdvancedAppointmentValidator();
            var result = validator.Validate(advancedAppointmentDto).IsValid;

            Assert.Equal(expected, result);

        }

        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {
            new object[] { new AdvancedAppointmentDto(new DateTime(2022, 10, 11), new DateTime(2022, 10, 15), 1, false), true},
            new object[] { new AdvancedAppointmentDto(new DateTime(2019, 10, 11), new DateTime(2022, 10, 15), 1, false), false},
            new object[] { new AdvancedAppointmentDto(new DateTime(2022, 10, 21), new DateTime(2022, 10, 14), 1, false), false},
            new object[] { new AdvancedAppointmentDto(new DateTime(2022, 10, 11), new DateTime(2012, 10, 15), 1, false), false},
            new object[] { new AdvancedAppointmentDto(new DateTime(2022, 10, 11), new DateTime(2022, 10, 15), 1, true), true},
            new object[] { new AdvancedAppointmentDto(new DateTime(2022, 10, 11), new DateTime(2022, 10, 15), 6, true), true},
            new object[] { new AdvancedAppointmentDto(new DateTime(), new DateTime(), 6, true), false},
            new object[] { new AdvancedAppointmentDto(new DateTime(2018, 10, 8), new DateTime(2017, 8, 7), 6, true), false}
        };



    }
}
