using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace WebApplicationSeleniumTests.Pages
{
    class HomePageAdmin
    {
            private readonly IWebDriver driver;
            public const string URI = "http://localhost:49900/#/admin";
            private IWebElement MaliciousUsersButton => driver.FindElement(By.Id("MaliciousUsers"));
            private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='MaliciousTable']/tbody/tr"));  
            private IWebElement BlockMaliciousUserButton => driver.FindElement(By.XPath("(//table[@id='MaliciousTable']/tbody/tr)[last()]/td[2]/button"));


            public HomePageAdmin(IWebDriver driver)
            {
                this.driver = driver;
            }

            public void ClickMaliciousUsersButton()
            {
                MaliciousUsersButton.Click();
            }

            public void BlockMaliciousUser() {
                BlockMaliciousUserButton.Click();
            }
            public void Block()
            {
                Thread.Sleep(3000);
                BlockMaliciousUserButton.Click();
            }

            public void waitForBlock()
            {
                Thread.Sleep(1000);
            }


            public int MaliciousUserCount()
            {
                return Rows.Count;
            }

            public bool BlockMaliciousUSerButtonEnabled()
            {
                return BlockMaliciousUserButton.Enabled;
            }

            public bool BlockMaliciousUSerButtonDisplayed()
            {
                return BlockMaliciousUserButton.Displayed;
            }

            public void EnsurePageIsDisplayed()
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                wait.Until(condition =>
                {
                    try
                    {
                        return Rows.Count > 0;
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }

}
