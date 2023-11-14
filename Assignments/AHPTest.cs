using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class AHPTest
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();            //initialising the chrome driver
            driver.Url = "https://www.amazon.com";  //inputing the amazon website as url
            driver.Manage().Window.Maximize();      //maximizing the webpage
        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            string title = driver.Title;
            Console.WriteLine("Title:{0}", title);
            Assert.That(driver.Title.Contains("Amazon"));   //checking whether the title contains the word amazon in it
            Console.WriteLine("Title Test Passed");         //if test passed this line is displayed
        }
        public void OrgTest()
        {
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains(".com"));       //checking whether the url contains .com 
            Console.WriteLine("Oganisation Test Passed");   //if url contains .com in it test passed
        }
        public void Destruct()
        {
            driver.Close();                                 //closing the current tab
        }
    }
}
