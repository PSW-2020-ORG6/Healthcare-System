using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://http://localhost:49900/#/landing";

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
