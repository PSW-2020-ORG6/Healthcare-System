using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    public class HeaderPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:49900/#/";
        private IWebElement LoginButton => driver.FindElement(By.Id("loginUser"));

        public HeaderPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickLogInButton()
        {
            LoginButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
