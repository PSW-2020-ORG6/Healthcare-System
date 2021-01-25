using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace WebApplicationSeleniumTests.Pages
{
    public class FeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:49900/#/feedbackPatient";
        private IWebElement FeedbackTextArea => driver.FindElement(By.Id("feedbackText"));
        private IWebElement CreateFeedbackButton => driver.FindElement(By.Id("create"));
        private IWebElement CheckboxAnonimous => driver.FindElement(By.Id("anonimous"));
        private IWebElement AddFeedbackButton => driver.FindElement(By.Id("addF"));

        public const string InvalidFeedbackMessage = "You need to enter a comment first.";

        public const string ValidFeedbackMessage = "Thanks for the feedback sent!";

        public FeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void InsertFeedback(string feedback)
        {
            FeedbackTextArea.SendKeys(feedback);
        }

        public void ClickCreateFeedbackButton()
        {
           CreateFeedbackButton.Click();
        }

        public void ClickAddFeedbackButton()
        {
            AddFeedbackButton.Click();
        }

        public void CheckAnonimous()
        {
            CheckboxAnonimous.Click();
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
