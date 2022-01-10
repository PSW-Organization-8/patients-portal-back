using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumProject.Pages
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/feedback";

        private IWebElement ContentElement => driver.FindElement(By.Id("content"));
        private IWebElement PublishableCheckBox => driver.FindElement(By.Id("publishable"));
        private IWebElement AnonymousCheckBox => driver.FindElement(By.Id("anonymous"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submitButton"));

        public const string EmptyContentMessage = "Please fill out the text field";


        public CreateFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool ContentElementDisplayed()
        {
            return ContentElement.Displayed;
        }
        public bool PublishableCheckBoxDisplayed()
        {
            return PublishableCheckBox.Displayed;
        }
        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertContent(string content)
        {
            ContentElement.SendKeys(content);
        }
        public void CheckPublishable()
        {
            PublishableCheckBox.Click();
        }
        public void CheckAnonymous()
        {
            AnonymousCheckBox.Click();
        }
        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }


        public string GetDialogMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }
        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }


        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(URI));
        }
        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
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
