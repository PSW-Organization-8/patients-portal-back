using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumProject.Pages
{
    public class PatientHomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200";

        private IWebElement FeedbackContent => driver.FindElement(By.Id("feedbackContent"));
        private IWebElement LogoutButton => driver.FindElement(By.Id("logoutButton"));

        public PatientHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetContentOfPublishedFeedback()
        {
            return FeedbackContent.Text;
        }

        public void ClickOnLogoutButton()
        {
            LogoutButton.Click();
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
