using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        public const string URI = "http://localhost:58526/feedbackView";
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
            Rows[0].FindElement(By.Id("approveButton")).Click();
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count >= 1;
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
