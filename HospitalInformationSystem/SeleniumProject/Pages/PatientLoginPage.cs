﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    public class PatientLoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/patientLogin";

        private IWebElement UsernameField => driver.FindElement(By.Id("usernameField"));
        private IWebElement PasswordField => driver.FindElement(By.Id("passwordField"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginButton"));

        public PatientLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void InsertUsername(string username)
        {
            UsernameField.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void Login()
        {
            LoginButton.Click();
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
