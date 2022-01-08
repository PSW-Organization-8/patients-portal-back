using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Pages;
using System;
using System.Threading;
using Xunit;

namespace SeleniumProject
{
    public class CreateFeedbackTests: IDisposable
    {
        private readonly IWebDriver driver;
        private CreateFeedbackPage createFeedbackPage;
        private FeedbacksPage feedbacksPage;
        private const int threadSleep = 1000;
        private int feedbacksCount = 0;

        public CreateFeedbackTests()
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
            feedbacksCount = feedbacksPage.FeedbacksCount();

            createFeedbackPage = new CreateFeedbackPage(driver);
            createFeedbackPage.EnsurePageIsDisplayed();
            createFeedbackPage.Navigate();


            Assert.Equal(driver.Url, CreateFeedbackPage.URI);

            Assert.True(createFeedbackPage.ContentElementDisplayed());
            Assert.True(createFeedbackPage.SubmitButtonElementDisplayed());
            Assert.True(createFeedbackPage.PublishableCheckBoxDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestCreateNoAnonymousNoPublishable()
        {
            
            createFeedbackPage.InsertContent("!Anonymous && !Publishable.");


            createFeedbackPage.CheckPublishable();


            createFeedbackPage.SubmitForm();


            feedbacksPage = new FeedbacksPage(driver);
            feedbacksPage.Navigate();
            feedbacksPage.EnsurePageIsDisplayed();


            Assert.Equal(feedbacksCount + 1, feedbacksPage.FeedbacksCount());
            
        }

        [Fact]
        public void TestCreateAnonymousNoPublishable()
        {
            createFeedbackPage.InsertContent("Anonymous && !Publishable.");


            createFeedbackPage.CheckAnonymous();


            createFeedbackPage.CheckPublishable();


            createFeedbackPage.SubmitForm();


            feedbacksPage = new FeedbacksPage(driver);
            feedbacksPage.Navigate();
            feedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, feedbacksPage.FeedbacksCount());

        }

        [Fact]
        public void TestCreateNoAnonymousPublishable()
        {
            createFeedbackPage.InsertContent("!Anonymous && Publishable.");

            createFeedbackPage.SubmitForm();

            feedbacksPage = new FeedbacksPage(driver);
            feedbacksPage.Navigate();
            feedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, feedbacksPage.FeedbacksCount());

        }

        [Fact]
        public void TestCreateAnonymousPublishable()
        {
            createFeedbackPage.InsertContent("Anonymous && Publishable.");

            createFeedbackPage.CheckAnonymous();

            createFeedbackPage.SubmitForm();

            feedbacksPage = new FeedbacksPage(driver);
            feedbacksPage.Navigate();
            feedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, feedbacksPage.FeedbacksCount());


        }

        [Fact]
        public void TestEmptyContent()
        {
            createFeedbackPage.SubmitForm();

            createFeedbackPage.WaitForAlertDialog();

            Assert.Equal(createFeedbackPage.GetDialogMessage(), CreateFeedbackPage.EmptyContentMessage);

            createFeedbackPage.ResolveAlertDialog();
        }
    }
}
