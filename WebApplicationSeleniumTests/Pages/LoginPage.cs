using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://http://localhost:49900/#/login";
        private IWebElement Username => driver.FindElement(By.Id("userNameId"));
        private IWebElement Password => driver.FindElement(By.Id("passwordId"));
        private IWebElement SubmitButton => driver.FindElement(By.Id("submitId"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver; 
        }

        public void InsertUsername(string username)
        {
            Username.SendKeys(username);
        }
        public void InsertPassword(string password)
        {
            Username.SendKeys(password);
        }
        public void SubmitClick()
        {
            SubmitButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
