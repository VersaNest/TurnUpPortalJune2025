using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalJune2025.Pages;

namespace TurnUpPortalJune2025.Utilities
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected WebDriverWait Wait(int timeoutInSeconds = 30)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }
        public IWebElement WaitUntilVisible(By locator, int timeout = 30)
        {
            return Wait(timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitUntilClickable(By locator, int timeoutInSeconds = 30)
        {
            return Wait(timeoutInSeconds).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public IAlert WaitForAlert(int timeoutInSeconds = 10)
        {
            return Wait(timeoutInSeconds).Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
