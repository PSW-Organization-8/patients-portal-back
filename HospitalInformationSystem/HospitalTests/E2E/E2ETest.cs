using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.E2E
{
    public class E2ETest
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [Test]
        public void test1()
        {
            driver.Url = "http://localhost:4200";
            IWebElement element = driver.FindElement(By.Id("doctor-link")); element.Click();
            element = driver.FindElement(By.Id("manage-shifts")); element.Click();
            

            element = driver.FindElement(By.Id("shifts"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Morning shift");

            element = driver.FindElement(By.Id("newShiftName"));
            element.Clear();
            element.SendKeys("Shift test 1");

            element = driver.FindElement(By.Id("shiftStart"));
            element.Clear();
            element.SendKeys("7:15");

            element = driver.FindElement(By.Id("shiftEnd"));
            element.Clear();
            element.SendKeys("13:30");

            element = driver.FindElement(By.Id("shift-save")); element.Click();
        }

        [Test]
        public void test2() 
        {
            driver.Url = "http://localhost:4200";
            IWebElement element = driver.FindElement(By.Id("doctor-link")); element.Click();
            element = driver.FindElement(By.Id("manage-shifts-1")); element.Click();

            element = driver.FindElement(By.Id("shifts"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Morning shift");

            element = driver.FindElement(By.Id("save")); element.Click();
        }

        [Test]
        public void test3()
        {
            driver.Url = "http://localhost:4200";
            IWebElement element = driver.FindElement(By.Id("doctor-link")); element.Click();
            element = driver.FindElement(By.Id("manage-vacations-1")); element.Click();

            element = driver.FindElement(By.Id("vacationDescription"));
            element.Clear();
            element.SendKeys("Summer Vacation 1");

            element = driver.FindElement(By.Id("startTime"));
            element.Clear();
            element.SendKeys("Mon Jun 06 2022 00:00:00");

            element = driver.FindElement(By.Id("endTime"));
            element.Clear();
            element.SendKeys("Mon Jun 06 2022 10:00:00");

            element = driver.FindElement(By.Id("save")); element.Click();
        }

        [Test]
        public void test4()
        {
            driver.Url = "http://localhost:4200";
            IWebElement element = driver.FindElement(By.Id("doctor-link")); element.Click();
            element = driver.FindElement(By.Id("doctor-workload-1")); element.Click();
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
