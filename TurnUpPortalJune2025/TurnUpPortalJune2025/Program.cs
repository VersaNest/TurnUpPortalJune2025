using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    public static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        //launch Turnup Portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io");
        Thread.Sleep(3000);
        driver.Manage().Window.Maximize();
        //Identify username textbox and enter valid username
        IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
        userNameTextbox.SendKeys("hari");
        //Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");
        //Identify login button and click it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        //Check if user logged in successfully
        IWebElement helloUser = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if(helloUser.Text == "Hello hari!")
        {
            Console.WriteLine("Userlogged in successfully");
        }
        else
        {
            Console.WriteLine("User not logged in successfully");
        }

    }
}