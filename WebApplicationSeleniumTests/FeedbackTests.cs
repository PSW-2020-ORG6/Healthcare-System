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
    public class AddFeedbackTests:IDisposable
    {
        private readonly IWebDriver driver;
        private LandingPage landingPage;
        private HeaderPage headerPage;
        private LoginPage loginPage;
        private HomePage homePage;
        private FeedbackPage feedbackPage;
        private FeedbackAdmin feedbackAdmin;

        public AddFeedbackTests()
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
        public void Test_successful_added_feedback()
        {
            loginPage.InsertUsername("email");
            loginPage.InsertPassword("sifra");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePage = new HomePage(driver);
            homePage.Navigate();
            Assert.Equal(driver.Url, HomePage.URI);
            homePage.ClickFeedbackButton();

            feedbackPage = new FeedbackPage(driver);
            feedbackPage.Navigate();
            Assert.Equal(driver.Url, FeedbackPage.URI);
            Thread.Sleep(500);

            feedbackPage.ClickCreateFeedbackButton();
            Thread.Sleep(1500);

            feedbackPage.InsertFeedback("The staff is great as is the website!");
            feedbackPage.ClickAddFeedbackButton();

            feedbackPage.WaitForAlertDialog();
            Assert.Equal(feedbackPage.GetDialogMessage(), FeedbackPage.ValidFeedbackMessage);
            feedbackPage.ResolveAlertDialog();
        }

        [Fact]
        public void Test_successful_added_feedback_by_anonimous()
        {
            loginPage.InsertUsername("email");
            loginPage.InsertPassword("sifra");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePage = new HomePage(driver);
            homePage.Navigate();
            Assert.Equal(driver.Url, HomePage.URI);
            homePage.ClickFeedbackButton();

            feedbackPage = new FeedbackPage(driver);
            feedbackPage.Navigate();
            Assert.Equal(driver.Url, FeedbackPage.URI);
            Thread.Sleep(500);

            feedbackPage.ClickCreateFeedbackButton();
            Thread.Sleep(1500);

            feedbackPage.InsertFeedback("The staff is great as is the website!");
            feedbackPage.CheckAnonimous();
            feedbackPage.ClickAddFeedbackButton();

            feedbackPage.WaitForAlertDialog();
            Assert.Equal(feedbackPage.GetDialogMessage(), FeedbackPage.ValidFeedbackMessage);
            feedbackPage.ResolveAlertDialog();
        }

        [Fact]
        public void Test_unsuccessful_added_feedback()
        {
            loginPage.InsertUsername("email");
            loginPage.InsertPassword("sifra");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePage = new HomePage(driver);
            homePage.Navigate();
            Assert.Equal(driver.Url, HomePage.URI);
            homePage.ClickFeedbackButton();

            feedbackPage = new FeedbackPage(driver);
            feedbackPage.Navigate();
            Assert.Equal(driver.Url, FeedbackPage.URI);
            Thread.Sleep(500);

            feedbackPage.ClickCreateFeedbackButton();
            Thread.Sleep(1500);

            feedbackPage.ClickAddFeedbackButton();

            feedbackPage.WaitForAlertDialog();
            Assert.Equal(feedbackPage.GetDialogMessage(), FeedbackPage.InvalidFeedbackMessage);
            feedbackPage.ResolveAlertDialog();
        }

        [Fact]
        public void Test_unsuccessful_added_feedback_by_anonimous()
        {
            loginPage.InsertUsername("email");
            loginPage.InsertPassword("sifra");
            loginPage.SubmitClick();
            Thread.Sleep(5000);

            homePage = new HomePage(driver);
            homePage.Navigate();
            Assert.Equal(driver.Url, HomePage.URI);
            homePage.ClickFeedbackButton();

            feedbackPage = new FeedbackPage(driver);
            feedbackPage.Navigate();
            Assert.Equal(driver.Url, FeedbackPage.URI);
            Thread.Sleep(500);

            feedbackPage.ClickCreateFeedbackButton();
            Thread.Sleep(1500);

            feedbackPage.CheckAnonimous();
            feedbackPage.ClickAddFeedbackButton();

            feedbackPage.WaitForAlertDialog();
            Assert.Equal(feedbackPage.GetDialogMessage(), FeedbackPage.InvalidFeedbackMessage);
            feedbackPage.ResolveAlertDialog();
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
            Thread.Sleep(1500);

            Assert.Equal(rowCountApproved + 1, feedbackAdmin.CountRowsTableApproved());
            Assert.Equal(rowCountDisapproved - 1, feedbackAdmin.CountRowsTableDisapproved());
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
            Thread.Sleep(2000);

            Assert.Equal(rowCountApproved - 1, feedbackAdmin.CountRowsTableApproved());
            Assert.Equal(rowCountDisapproved + 1, feedbackAdmin.CountRowsTableDisapproved());
        }
    }
}
