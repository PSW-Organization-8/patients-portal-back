using HospitalClassLib.SharedModel;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLib.MedicalRecords.Repository.ReferralRepo
{
    interface IReferralRepository:IGenericRepository<Referral,String>
    {
    }
}
