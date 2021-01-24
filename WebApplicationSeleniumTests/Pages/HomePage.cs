using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:49900/#/patient";
        private IWebElement AppointmentButton => driver.FindElement(By.Id("AppointmentsShow"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAppointmentButton()
        {
            AppointmentButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
