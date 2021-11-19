using HospitalClassLib.Schedule.Model;
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
        private static string retVal;
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
            //TODO: generate unique token
            patient.Token = new Random().Next(1, 5000);
            //TODO: send email (async func) with generated token
            SendEmail(patient.Token);
            //TODO: add patient in database
            return patientRepository.Create(patient);
        }
        public string SendEmail(int patientToken)
        {
            Email(GetMailMessage(patientToken));
            return retVal;
        }
        public static string GetMailMessage(int patientToken)
        {
            string link = "http://localhost:16934/api/patient/patientActivation/" + patientToken;
            return "<a href=" + link + ">ACTIVATE ACCOUNT</a>";
        }
        public static void Email(string htmlString)
        {
            try
            {
                SmtpClient client = new SmtpClient()
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
                MailAddress fromEmail = new MailAddress("pswtestmail@gmail.com");
                MailAddress toEmail = new MailAddress("pswtestmail@gmail.com");
                MailMessage message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = "Naslov",
                    Body = "Ovo je tekst poruke."
                };
                message.IsBodyHtml = true;
                message.Body = htmlString;
                message.To.Add(toEmail);
                client.Send(message);
                retVal = "Success!";
            }
            catch(Exception ex)
            {
                retVal = ex.Message;
            }
        }
        public void ActivatePatientAccount(int patientToken)
        {
            Patient patient = patientRepository.GetByToken(patientToken);
            patient.IsActivated = true;
            patientRepository.Update(patient);
        }
    }
}
