using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    public class ManagerHomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:58526";

        private IWebElement LogoutButton => driver.FindElement(By.Id("logoutButton"));

        public ManagerHomePage(IWebDriver driver)
        {
            this.driver = driver;
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
