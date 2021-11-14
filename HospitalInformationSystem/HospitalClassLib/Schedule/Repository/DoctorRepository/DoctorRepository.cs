using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System.Collections.Generic;
using System.Linq;

namespace HospitalClassLib.Schedule.Repository.DoctorRepository
{
    public class DoctorRepository : AbstractSqlRepository<Doctor, int>, IDoctorRepository
    {
        private MyDbContext dbContext;

        public DoctorRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(Doctor entity)
        {
            return entity.Id;
        }

        public List<Doctor> GetLessOccupiedDoctors()
        {
            return dbContext.Doctors.Where(x => x.Patients.Count < dbContext.Doctors.OrderBy(p => p.Patients.Count).First().Patients.Count + 3 && 
            x.DoctorSpecialization.Equals(Specialization.FamilyPhysician)).ToList();
        }
    }
}
