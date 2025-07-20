using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalJune2025.Utilities;

namespace TurnUpPortalJune2025.Pages
{
    public class LoginPage : BasePage
    {
        
        public LoginPage(IWebDriver driver) : base(driver) { }
        
        public void UserLogin(string userName, string password)
        {
            IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
            userNameTextbox.SendKeys(userName);

            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys(password);

            IWebElement loginButton = WaitUntilClickable(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();

            Thread.Sleep(3000);

            IWebElement helloUser = WaitUntilVisible(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            Assert.That(helloUser.Text == "Hello hari!", "User not logged in successfully");
        }

    }
}
