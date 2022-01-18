using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLib.MedicalRecords.Repository.ReceiptRepo
{
    public interface IReceiptRepository:IGenericRepository<Receipt,long>
    {
    }
}
