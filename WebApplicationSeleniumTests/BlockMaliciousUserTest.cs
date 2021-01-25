using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebApplicationSeleniumTests.Pages;
using Xunit;

namespace WebApplicationSeleniumTests
{
    public class BlockMaliciousUserTest : IDisposable
    {
        private readonly IWebDriver driver;
        private LandingPage landingPage;
        private HeaderPage headerPage;
        private LoginPage loginPage;
        private HomePageAdmin homePageAdmin;
        private int maliciousUserCount = 0;


        public BlockMaliciousUserTest()
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
        public void Test_Successful_block_malicious_user()
        {
            loginPage.InsertUsername("a");
            loginPage.InsertPassword("b");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePageAdmin = new HomePageAdmin(driver);
            homePageAdmin.Navigate();
            Assert.Equal(driver.Url, HomePageAdmin.URI);
            Thread.Sleep(10000);

            homePageAdmin.ClickMaliciousUsersButton();
            Thread.Sleep(15000);

            maliciousUserCount = homePageAdmin.MaliciousUserCount();
            homePageAdmin.BlockMaliciousUser();
            Assert.True(homePageAdmin.BlockMaliciousUSerButtonEnabled());

            Thread.Sleep(10000);
            Assert.Equal(maliciousUserCount - 1, homePageAdmin.MaliciousUserCount());

        }
    }
}
