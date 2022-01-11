using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumProject
{
    public class BanPatientTests
    {
        private readonly IWebDriver driver;

        private PatientLoginPage patientLoginPage;

        private ManagerLoginPage managerLoginPage;
        private ManagerHomePage managerHomePage;
        private BanPatientPage banPatientPage;

        public BanPatientTests()
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

            ManagerLogin();
        }

        [Fact]
        private void TestBanPatient()
        {
            banPatientPage = new BanPatientPage(driver);

            banPatientPage.Navigate();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("banButton")));
            banPatientPage.ClickOnBanButton();

            ManagerLogout();

            PatientLogin();

            patientLoginPage.WaitForAlertDialog();
            Assert.Equal(patientLoginPage.GetDialogMessage(), BanPatientPage.EmptyContentMessage);
        }

        private void ManagerLogin()
        {
            managerLoginPage = new ManagerLoginPage(driver);
            managerLoginPage.Navigate();
            managerLoginPage.EnsurePageIsDisplayed();

            managerLoginPage.InsertUsername("radisa");
            managerLoginPage.InsertPassword("radisa");
            managerLoginPage.Login();
        }

        private void ManagerLogout()
        {
            managerHomePage = new ManagerHomePage(driver);
            managerHomePage.Navigate();
            managerHomePage.EnsurePageIsDisplayed();
            managerHomePage.ClickOnLogoutButton();
        }

        private void PatientLogin()
        {
            patientLoginPage = new PatientLoginPage(driver);
            patientLoginPage.Navigate();
            patientLoginPage.EnsurePageIsDisplayed();
            patientLoginPage.InsertUsername("mare");
            patientLoginPage.InsertPassword("maric");
            patientLoginPage.Login();
        }
    }
}
