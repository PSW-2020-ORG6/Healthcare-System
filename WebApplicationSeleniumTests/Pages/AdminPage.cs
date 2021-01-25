using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    public class AdminPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:49900/#/admin";
        private IWebElement FeedbackButton => driver.FindElement(By.Id("FeedbacksControl"));

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickFeedbackButton()
        {
            FeedbackButton.Click();
        }
        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
