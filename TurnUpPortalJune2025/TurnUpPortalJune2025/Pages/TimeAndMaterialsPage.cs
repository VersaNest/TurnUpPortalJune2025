using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalJune2025.Utilities;

namespace TurnUpPortalJune2025.Pages
{
    public class TimeAndMaterialsPage : BasePage
    {
        public TimeAndMaterialsPage(IWebDriver driver) : base(driver) { }

        public void SelectTMOption()
        {
            
            Thread.Sleep(3000);
            IWebElement administrationTab = WaitUntilClickable(By.XPath("//a[@class='dropdown-toggle']"));
        
            administrationTab.Click();
            
            Thread.Sleep(3000);
            IWebElement timeAndMaterialsOption = WaitUntilClickable(By.XPath("//a[@href='/TimeMaterial']"));
          
            timeAndMaterialsOption.Click();

        }
        public void CreateNewRecord()
        {
            IWebElement createNewTimeButton = WaitUntilClickable(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewTimeButton.Click();

            IWebElement selectTypeCode = WaitUntilClickable(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
            selectTypeCode.Click();

            IWebElement selectTime = WaitUntilVisible(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            selectTime.Click();

            IWebElement enterCodeBox = WaitUntilVisible(By.Id("Code"));

            enterCodeBox.SendKeys("TestCode");

            IWebElement enterDescription = WaitUntilVisible(By.Id("Description"));
   
            enterDescription.SendKeys("Test Description");


            IWebElement enterPrice = WaitUntilVisible(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
  
            enterPrice.SendKeys("14");

            IWebElement saveButton = WaitUntilClickable(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(10000);
            IWebElement goLastPage = WaitUntilClickable(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goLastPage.Click();
            Thread.Sleep(3000);
            IWebElement lastRowRecord = WaitUntilVisible(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(3000);
            Assert.That(lastRowRecord.Text == "TestCode", "Record not found");
           

        }

        public void EditLastRowRecord()
        {

            IWebElement editLastRowRecord = WaitUntilClickable(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editLastRowRecord.Click();
            IWebElement editCodeBox = WaitUntilVisible(By.Id("Code"));
            Console.WriteLine("Code Box found"); 
            editCodeBox.Clear();
            editCodeBox.SendKeys("NewTestRush");


            var editPrice = WaitUntilVisible(By.XPath("//input[contains(@class, 'k-formatted-value') and contains(@class, 'k-input')]"));
            Console.WriteLine("Price Box found"); 
            editPrice.Clear();
            Console.WriteLine("Price Box cleared");
            //editPrice.SendKeys("15");

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Set the value using JavaScript and trigger the 'change' event
            js.ExecuteScript("arguments[0].value = '13'; arguments[0].dispatchEvent(new Event('change'));", editPrice);

            Console.WriteLine("Price entered");

            IWebElement editSaveButton = WaitUntilClickable(By.XPath("//*[@id=\"SaveButton\"]"));
            editSaveButton.Click();
            Thread.Sleep(10000);
            Console.WriteLine("REcord edited");
          
            IWebElement goLastPageEdit = WaitUntilClickable(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goLastPageEdit.Click();

            IWebElement newLastRowRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newLastRowRecord.Text == "NewTestRush", "Record not found");
           
        }

        public void DeleteLastRowRecord()
        {
            IWebElement deleteLastRowRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteLastRowRecord.Click();

            Console.WriteLine("Delete button clicked");
            IAlert alert = WaitForAlert();
            alert.Accept();
            Console.WriteLine("Accept button clicked");
            IWebElement newLastRowRecord2 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(2000);
            Console.WriteLine("Last REcord checked");
            Assert.That(newLastRowRecord2.Text == "NewTestRush", "Record deleted");
         

        }

    }
}
