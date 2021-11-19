﻿using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class PatientService
    {
        private readonly IPatientRepository patientRepository;
        private const int UNIQUE_NUMBER_LENGTH = 10;
        private const int RANDOM_NUMBER_LENGTH = 10;
        public PatientService() { }
        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public Patient Get(int id)
        {
            return patientRepository.Get(id);
        }
        public Patient RegisterPatient(Patient patient)
        {
            //TODO: add patient in database
            Patient newPatient = patientRepository.Create(patient);
            //TODO: generate unique token
            patient.Token = GetUniqueToken(newPatient.Id);
            patientRepository.Update(patient);
            //TODO: send email (async func) with generated token
            SendEmail(patient.Token);

            return newPatient;
        }
        /*public string SendEmail(string patientToken)
        {
            SendEmail(GetMailMessage(patientToken));
            return retVal;
        }*/
        public static void SendEmail(string patientToken)
        {
            try { CreateSmtpClient().Send(CreateMessage(GetMailMessage(patientToken))); }
            catch (Exception ex) { }
        }
        private static SmtpClient CreateSmtpClient()
        {
            return new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "pswtestmail@gmail.com",
                    Password = "pswtestmail567"
                }
            };
        }
        private static MailMessage CreateMessage(string htmlString)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress("pswtestmail@gmail.com"),
                Subject = "Naslov",
                Body = "Ovo je tekst poruke."
            };
            message.IsBodyHtml = true;
            message.Body = htmlString;
            message.To.Add(new MailAddress("pswtestmail@gmail.com"));
            return message;
        }
        public static string GetMailMessage(string patientToken)
        {
            string link = "http://localhost:16934/api/patient/patientActivation/" + patientToken;
            return "<a href=" + link + ">ACTIVATE ACCOUNT</a>";
        }
        static String EncodeIntAsString(int input, int maxLength = 0)
        {
            Char[] allowedList = new Char[] {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z' , '$', '%', '#', '@'};
            int allowedSize = allowedList.Length;
            StringBuilder result = new StringBuilder(input.ToString().Length);

            int moduloResult;
            while (input > 0)
            {
                moduloResult = input % allowedSize;
                input /= allowedSize;
                result.Insert(0, allowedList[moduloResult]);
            }

            if (maxLength > result.Length){ result.Insert(0, new String(allowedList[0], maxLength - result.Length)); }
            if (maxLength > 0) return result.ToString().Substring(0, maxLength);
            else return result.ToString();
        }
        static String GetUniqueToken(int patientId)
        {
            Random randomizer = new Random((int)(
                    DateTime.Now.Ticks + (DateTime.Now.Ticks > patientId ? DateTime.Now.Ticks / (patientId + 1) : patientId / DateTime.Now.Ticks)
                )
            );
            return EncodeIntAsString(randomizer.Next(1, int.MaxValue), UNIQUE_NUMBER_LENGTH) + EncodeIntAsString(patientId, RANDOM_NUMBER_LENGTH);
        }
        public void ActivatePatientAccount(string patientToken)
        {
            Patient patient = patientRepository.GetByToken(patientToken);
            patient.IsActivated = true;
            patientRepository.Update(patient);
        }
    }
}
