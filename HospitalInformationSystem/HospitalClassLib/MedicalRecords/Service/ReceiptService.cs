using HospitalClassLib.MedicalRecords.Repository.ReceiptRepo;
using HospitalClassLib.MedicalRecords.Service.Interface;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.MedicalRecords.Service
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository repository;

        public ReceiptService(IReceiptRepository repository)
        {
            this.repository = repository;
        }

        public Receipt Create(Receipt newReceipt)
        {
            return repository.Create(newReceipt);
        }

        public bool Delete(long id)
        {
            return repository.Delete(id);
        }

        public Receipt Get(long id)
        {
            return repository.Get(id);
        }

        public List<Receipt> GetAll()
        {
            return repository.GetAll();
        }

        public Receipt Update(Receipt receipt)
        {
            return repository.Update(receipt);
        }
    }
}
