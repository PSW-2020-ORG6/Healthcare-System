using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace WebApplicationSeleniumTests.Pages
{
    public class AppointmentPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://http://localhost:49900/#/appointments";
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='tableAppontments']/tbody/tr"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("(//table[@id='tableAppontments']/tbody/tr)[last()]/td[7]/button"));
        public string Title => driver.Title;

        public AppointmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Cancel()
        {
            Thread.Sleep(3000);
            CancelButton.Click();
        }

        public void waitForCancel()
        {
            Thread.Sleep(1000);
        }

        public int AppointmentsCount()
        {
            return Rows.Count;
        }

        public bool CancelButtonEnabled()
        {
            return CancelButton.Enabled;
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
