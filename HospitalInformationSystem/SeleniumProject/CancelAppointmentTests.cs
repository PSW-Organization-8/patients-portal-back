using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Pages;
using System;
using System.Threading;
using Xunit;


namespace SeleniumProject
{
    public class CancelAppointmentTests
    {
        private readonly IWebDriver driver;
        private PatientRecordPage patientRecordPage;
        private PatientLoginPage patientLoginPage;

        public CancelAppointmentTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);
        }

        [Fact]
        public void TestCancelAppointment()
        {
            PatientLogin();
            patientRecordPage = new PatientRecordPage(driver);
            patientRecordPage.EnsurePageIsDisplayed();
            patientRecordPage.ClickOnCancelAppointmentButton();

            Assert.True(patientRecordPage.AppointmentCanceledButtonDisplayed());
        }

        private void PatientLogin()
        {
            patientLoginPage = new PatientLoginPage(driver);
            patientLoginPage.Navigate();
            patientLoginPage.EnsurePageIsDisplayed();
            patientLoginPage.InsertUsername("pera");
            patientLoginPage.InsertPassword("pera");
            patientLoginPage.Login();
        }
    }
}
