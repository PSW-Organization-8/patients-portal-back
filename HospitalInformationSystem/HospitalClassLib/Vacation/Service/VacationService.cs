using HospitalClassLib.SharedModel;
using HospitalClassLib.Vacation.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Vacation.Service
{
    public class VacationService
    {
        private readonly IVacationRepository vacationRepository;


        public VacationService(IVacationRepository vacationRepository)
        {
            this.vacationRepository = vacationRepository;

        }

        public List<VacationPeriod> GetAllVacations()
        {
            return vacationRepository.GetAll();
        }

        public void CreateAllVacations(List<VacationPeriod> allNewVacations)
        {
            foreach (VacationPeriod newVacations in allNewVacations)
            {
                CreateVacations(newVacations);
            }
        }

        public VacationPeriod GetVacationByID(long ID)
        {
            List<VacationPeriod> allVacation = GetAllVacations();
            foreach (VacationPeriod vacation in allVacation)
            {
                if (vacation.ID == ID)
                    return vacation;
            }

            return null;
        }

        public VacationPeriod CreateVacations(VacationPeriod newVacations)
        {
            return vacationRepository.Create(newVacations);
        }

        public VacationPeriod EditVacations(VacationPeriod newVacations)
        {
            return vacationRepository.Update(newVacations);
        }
    }
}
