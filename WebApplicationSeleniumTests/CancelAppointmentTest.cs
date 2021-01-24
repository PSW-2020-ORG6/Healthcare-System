using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using Xunit;
using WebApplicationSeleniumTests.Pages;
using System.Threading;

namespace WebApplicationSeleniumTests
{
    public class CancelAppointmentTest : IDisposable
    {
        private readonly IWebDriver driver;
        private LandingPage landingPage;
        private HeaderPage headerPage;
        private LoginPage loginPage;
        private HomePage homePage;
        private AppointmentPage appointmentPage;

        public CancelAppointmentTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);

            landingPage = new LandingPage(driver);
            landingPage.Navigate();
            headerPage = new HeaderPage(driver);
            headerPage.Navigate();
            headerPage.ClickLogInButton();
            Thread.Sleep(100);

            loginPage = new LoginPage(driver);
            loginPage.Navigate();
            loginPage.InsertUsername("email");
            loginPage.InsertPassword("sifra");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePage = new HomePage(driver);
            homePage.ClickAppointmentButton();
            appointmentPage = new AppointmentPage(driver);
            Thread.Sleep(8000);

        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Cancel_appointment()
        {

        }
    }
}
