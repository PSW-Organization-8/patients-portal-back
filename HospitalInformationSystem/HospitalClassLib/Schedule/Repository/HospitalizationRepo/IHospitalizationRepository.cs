using HospitalClassLib.Schedule.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLib.Schedule.Repository.HospitalizationRepo
{
    interface IHospitalizationRepository: IGenericRepository<Hospitalization, String>
    {

    }
}
