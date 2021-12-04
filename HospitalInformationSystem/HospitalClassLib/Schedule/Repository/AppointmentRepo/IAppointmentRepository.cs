﻿using HospitalClassLib.Schedule.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.Schedule.Repository.AppointmentRepo
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        Appointment Get(int id);
        Appointment Update(Appointment appointment);
        Appointment Create(Appointment appointment);
        bool ExistsById(int id);
        bool Delete(int id);
        List<Appointment> GetByPatient(int id);
        List<DateTime> GetFreeInSpecificDay(int day, int doctorId);
    }
}
