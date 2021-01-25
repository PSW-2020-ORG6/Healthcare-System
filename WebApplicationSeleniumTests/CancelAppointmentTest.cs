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
        private int appointmentCount = 0;
        private int cancelAppointmentCount = 0;

        public CancelAppointmentTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            
            options.AddArguments("disable-infobars");           
            options.AddArguments("--disable-extensions");      
            options.AddArguments("--disable-gpu");              
            options.AddArguments("--disable-dev-shm-usage");    
            options.AddArguments("--no-sandbox");           
            options.AddArguments("--disable-notifications");  

            driver = new ChromeDriver(options);

            landingPage = new LandingPage(driver);
            landingPage.Navigate();
            Assert.Equal(driver.Url, LandingPage.URI);
            headerPage = new HeaderPage(driver);
            headerPage.Navigate();
            Assert.Equal(driver.Url, HeaderPage.URI);
            headerPage.ClickLogInButton();
            Thread.Sleep(100);
            
            loginPage = new LoginPage(driver);
            loginPage.Navigate();
            Assert.Equal(driver.Url, LoginPage.URI);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Test_Successful_canceled_appointment()
        {
            loginPage.InsertUsername("email");
            loginPage.InsertPassword("sifra");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePage = new HomePage(driver);
            homePage.Navigate();
            Assert.Equal(driver.Url, HomePage.URI);
            homePage.ClickAppointmentButton();
            appointmentPage = new AppointmentPage(driver);
            appointmentPage.Navigate();
            Assert.Equal(driver.Url, AppointmentPage.URI);
            Thread.Sleep(45000);
            appointmentPage.EnsurePageIsDisplayed();
            appointmentCount = appointmentPage.AppointmentsCount();
            cancelAppointmentCount = appointmentPage.CancelAppointmentsCount();
            Assert.True(appointmentPage.CancelButtonDisplayed());
            appointmentPage.Cancel();
            Thread.Sleep(10000);
            Assert.Equal(appointmentCount - 1, appointmentPage.AppointmentsCount());
            Assert.Equal(cancelAppointmentCount + 1, appointmentPage.CancelAppointmentsCount());

        }
    }
}
