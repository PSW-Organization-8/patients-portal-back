using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.MedicalRecords.Repository.ReceiptRepo
{
    public class ReceiptRepository : AbstractSqlRepository<Receipt, long>, IReceiptRepository
    {
        public ReceiptRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Receipt entity)
        {
            return entity.ReceiptID;
        }
    }
}
