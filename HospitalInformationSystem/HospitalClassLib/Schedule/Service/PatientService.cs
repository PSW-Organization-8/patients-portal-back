using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

        public Patient GetByUsername(string username)
        {
            return patientRepository.GetByUsername(username);
        }

        public List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }
        public Patient RegisterPatient(Patient patient)
        {
            Patient newPatient = patientRepository.Create(patient);
            patient.Token = GetUniqueToken(newPatient.Id);
            patientRepository.Update(patient);
            SendEmail(patient.Token);

            return patient;
        }
        public static void SendEmail(string patientToken)
        {
            Thread thread = new Thread(() =>
            {
                try { CreateSmtpClient().Send(CreateMessage(GetMailMessage(patientToken))); }
                catch (Exception ex) { }
            });

            thread.Start();
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
            string link = "http://localhost:16934/api/patient/activate?patientToken=" + patientToken;

            return "Hello,<br> Thank you for joining Cura Infinita.<br><br>"
                + "We would like to confirm that your account was created successfully.<br><br>"
                + "To access Cura Infinita click the link below.<br><br>"
                + "<a  href=" + link + ">ACTIVATE ACCOUNT</a><br><br>"
                + "If you experience any issues logging into your account, reach out to us at [pswtestmail@gmail.com].<br><br>"
                + "Best,<br>"
                + "The Cura Infinita  team.";
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
            patient.PatientAccountStatus.IsActivated = true;
            patientRepository.Update(patient);
        }
        public Patient GetByToken(string patientToken)
        {
            return patientRepository.GetByToken(patientToken);
        }

        public bool BanPatientById(int id)
        {
            Patient patient = patientRepository.Get(id);
            patient.PatientAccountStatus.IsBanned = true;
            patientRepository.Update(patient);

            return true;
        }

        public bool UnbanPatientById(int id)
        {
            Patient patient = patientRepository.Get(id);
            patient.PatientAccountStatus.IsBanned = false;
            patientRepository.Update(patient);

            return true;
        }
    }
}
