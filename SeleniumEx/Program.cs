using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new  ChromeDriver();

driver.Url = "https://www.google.com";
Thread.Sleep(2000);
string title = driver.Title;
try
{
    Assert.AreEqual("Goooogle", title);
    Console.WriteLine("Test Passed");
}
catch(AssertionException)
{
    Console.WriteLine("Test Failed");
}
driver.Close();