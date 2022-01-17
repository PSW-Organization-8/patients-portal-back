using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    public class FeedbacksPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:58526/feedbackView"; //значи ово је ури
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='feedbacksTable']/tbody/tr"));
        public FeedbacksPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int FeedbacksCount()
        {
            return Rows.Count;
        }

        public string GetPublishableFeedbackContent()
        {
            return "\"" + Rows[0].FindElement(By.Id("feedbackContent")).Text + "\"";
        }

        public void ClickOnApproveButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("approveButton")));
            Rows[0].FindElement(By.Id("approveButton")).Click();
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("feedbacksTable")));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
