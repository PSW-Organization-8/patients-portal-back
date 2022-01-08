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
        private PatientHomePage patientHomePage;

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

            feedbacksPage = new FeedbacksPage(driver);
            feedbacksPage.Navigate();
            feedbacksPage.EnsurePageIsDisplayed();
        }

        [Fact]
        public void TestClickOnApproveButton()
        {
            String feedbackContent = feedbacksPage.GetPublishableFeedbackContent();
            feedbacksPage.ClickOnApproveButton();

            patientHomePage = new PatientHomePage(driver);
            patientHomePage.Navigate();
            patientHomePage.EnsurePageIsDisplayed();

            String expectedContent = patientHomePage.GetContentOfPublishedFeedback();

            Assert.Equal(feedbackContent, expectedContent);

            Thread.Sleep(2000);
        }

    }
}
