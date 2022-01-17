using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumProject.Pages
{
    public class BanPatientPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:58526/banPatient";
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='banPatientTable']/tbody/tr"));

        public const string EmptyContentMessage = "Wrong username or password!";

        public BanPatientPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnBanButton()
        {
            Rows[0].FindElement(By.Id("banButton")).Click();
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return Rows[1].FindElement(By.Id("banButton")).Displayed;
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
