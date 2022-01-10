using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Pages;
using System;
using System.Threading;
using Xunit;

namespace SeleniumProject
{
    public class PublishFeebackTests
    {

        private readonly IWebDriver driver;

        private FeedbacksPage feedbacksPage;
        private ManagerLoginPage managerLoginPage;
        private ManagerHomePage managerHomePage;

        private PatientHomePage patientHomePage;
        private PatientLoginPage patientLoginPage;

        public PublishFeebackTests()
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
            Thread.Sleep(1000);
            feedbacksPage = new FeedbacksPage(driver);
            feedbacksPage.Navigate();
            feedbacksPage.EnsurePageIsDisplayed();
        }

        [Fact]
        public void TestPublishFeedback()
        {
            String feedbackContent = feedbacksPage.GetPublishableFeedbackContent();
            feedbacksPage.ClickOnApproveButton();

            ManagerLogout();

            PatientLogin();

            patientHomePage = new PatientHomePage(driver);
            patientHomePage.Navigate();
            patientHomePage.EnsurePageIsDisplayed();

            String expectedContent = patientHomePage.GetContentOfPublishedFeedback();

            Assert.Equal(feedbackContent, expectedContent);

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
            patientLoginPage.InsertUsername("pera");
            patientLoginPage.InsertPassword("pera");
            patientLoginPage.Login();
        }

    }
}
