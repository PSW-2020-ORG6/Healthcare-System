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
    public class ApproveOrDisapproveFeedbacksTests : IDisposable
    {
        private readonly IWebDriver driver;
        private LandingPage landingPage;
        private HeaderPage headerPage;
        private LoginPage loginPage;
        private FeedbackAdmin feedbackAdmin;


        public ApproveOrDisapproveFeedbacksTests()
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
        public void Test_successful_approved_feedback()
        {
            loginPage.InsertUsername("a");
            loginPage.InsertPassword("b");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            feedbackAdmin = new FeedbackAdmin(driver);
            feedbackAdmin.Navigate();
            Assert.Equal(driver.Url, FeedbackAdmin.URI);
            Thread.Sleep(1000);

            feedbackAdmin.ClickTabFeedbackDisapproved();
            int rowCountApproved = feedbackAdmin.CountRowsTableApproved();
            int rowCountDisapproved = feedbackAdmin.CountRowsTableDisapproved();
            Thread.Sleep(5000);

            feedbackAdmin.ClickApproveFeedbackButton();
            Thread.Sleep(200);

            Assert.Equal(rowCountApproved+1, feedbackAdmin.CountRowsTableApproved());
            Assert.Equal(rowCountDisapproved-1, feedbackAdmin.CountRowsTableDisapproved());
        }

        [Fact]
        public void Test_successful_disapproved_feedback()
        {
            loginPage.InsertUsername("a");
            loginPage.InsertPassword("b");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            feedbackAdmin = new FeedbackAdmin(driver);
            feedbackAdmin.Navigate();
            Assert.Equal(driver.Url, FeedbackAdmin.URI);
            Thread.Sleep(1000);

            feedbackAdmin.ClickTabFeedbackApproved();
            int rowCountApproved = feedbackAdmin.CountRowsTableApproved();
            int rowCountDisapproved = feedbackAdmin.CountRowsTableDisapproved();
            Thread.Sleep(5000);

            feedbackAdmin.ClickDisapproveFeedbackButton();
            Thread.Sleep(200);

            Assert.Equal(rowCountApproved -1, feedbackAdmin.CountRowsTableApproved());
            Assert.Equal(rowCountDisapproved + 1, feedbackAdmin.CountRowsTableDisapproved());
        }
    }
}
