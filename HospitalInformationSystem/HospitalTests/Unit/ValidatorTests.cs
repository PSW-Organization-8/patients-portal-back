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
        public void Validator_id_correct(int id, bool expected)
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

    }
}
