using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace WebApplicationSeleniumTests.Pages
{
    public class FeedbackAdmin
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:49900/#/feedbackAdmin";
        private IWebElement TabFeedbackApproved => driver.FindElement(By.Id("tabApprovedF"));
        private IWebElement TableApproved => driver.FindElement(By.Id("tableApproved"));
        private IWebElement TableDisapproved => driver.FindElement(By.Id("tableDisapproved"));
        private IWebElement TabFeedbackDisapproved => driver.FindElement(By.Id("tabDisapprovedF"));
        private ReadOnlyCollection<IWebElement> RowsApproved => driver.FindElements(By.XPath("//table[@id='tableApproved']/tbody/tr"));
        private IWebElement ButtonApprove => driver.FindElement(By.XPath("(//table[@id='tableDisapproved']/tbody/tr)[last()]/td[4]/button"));
        private ReadOnlyCollection<IWebElement> RowsDisapproved => driver.FindElements(By.XPath("//table[@id='tableDisapproved']/tbody/tr"));
        private IWebElement ButtonDisapprove => driver.FindElement(By.XPath("(//table[@id='tableApproved']/tbody/tr)[last()]/td[4]/button"));

        public FeedbackAdmin(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void waitForCancel()
        {
            Thread.Sleep(1000);
        }

        public void ClickApproveFeedbackButton()
        {
            ButtonApprove.Click();
        }
        public void ClickTabFeedbackApproved()
        {
            TabFeedbackApproved.Click();
        }

        public void ClickDisapproveFeedbackButton()
        {
            ButtonDisapprove.Click();
        }
        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void ClickTabFeedbackDisapproved()
        {
            TabFeedbackDisapproved.Click();
        }

        public int CountRowsTableApproved()
        {
            return RowsApproved.Count;
        }
        public int CountRowsTableDisapproved()
        {
            return RowsDisapproved.Count;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return RowsApproved.Count > 0;
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
    }
}
