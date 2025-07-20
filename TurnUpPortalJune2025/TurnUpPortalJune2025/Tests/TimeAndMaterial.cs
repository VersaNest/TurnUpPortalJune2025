using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography.X509Certificates;
using TurnUpPortalJune2025.Pages;
using TurnUpPortalJune2025.Utilities;



public class TimeAndMaterial : BaseTest
{
  

    [Test]
    public void CreateRecord()
    {

        var createTMRecord = new TimeAndMaterialsPage(driver);
        Thread.Sleep(3000);
        createTMRecord.SelectTMOption();
        Thread.Sleep(3000);
        createTMRecord.CreateNewRecord();
        Thread.Sleep(3000);
        createTMRecord.EditLastRowRecord();
        Thread.Sleep(3000);
        createTMRecord.DeleteLastRowRecord();
    }
}