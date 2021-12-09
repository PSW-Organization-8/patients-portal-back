using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.MedicalRecords.Service.Interface
{
    public interface IReceiptService
    {
        List<Receipt> GetAll();

        Receipt Get(long id);

        Receipt Create(Receipt newReceipt);

        bool Delete(long id);

        Receipt Update(Receipt receipt);
    }
}
