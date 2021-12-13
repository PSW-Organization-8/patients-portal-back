using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class IdValidator
    {
        public bool CheckId(Object id)
        {
            return (int)id > 0 && id != null;
        }
    }
}
