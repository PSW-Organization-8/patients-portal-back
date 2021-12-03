using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public class ReceiptMapper
    {

        public static ReceiptDto ReceiptToReceiptDto(Receipt receipt, Doctor doctor, Patient patient, long pharmacyId) {

            return new ReceiptDto(receipt.MedicineName, receipt.Amount, receipt.Diagnosis, doctor.FullName, patient.FullName, receipt.Date, pharmacyId);
        }
    }
}
