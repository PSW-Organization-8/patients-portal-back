using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumProject.Pages
{
    public class PatientRecordPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/record";

        private IWebElement CancelAppointmentButton => driver.FindElement(By.Id("cancelAppointmentButton"));
        public PatientRecordPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnCancelAppointmentButton()
        {
            CancelAppointmentButton.Click();
        }

        public bool AppointmentCanceledButtonDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("appointmentCanceledButton"))).Displayed;
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
