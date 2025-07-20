using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalJune2025.Pages;

namespace TurnUpPortalJune2025.Utilities
{
    public class BaseTest
    {
        protected IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io");
            driver.Manage().Window.Maximize();

            var loginPage = new LoginPage(driver);

            loginPage.UserLogin("hari", "123123");
        }



        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }

    }

}
