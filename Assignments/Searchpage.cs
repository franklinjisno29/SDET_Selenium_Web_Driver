using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignments
{
    internal class Searchpage
    {
        IWebDriver? driver;
        public void OpenBrowser()
        {
            driver = new ChromeDriver();            //initialising the chrome driver
            driver.Url = "https://www.google.com";  //inputing the google website as url
            driver.Manage().Window.Maximize();      //maximizing the webpage
            driver.Navigate().GoToUrl("https://www.yahoo.com"); //navigate to yahoo home page
            Thread.Sleep(2000);                     
            driver.Navigate().Back();               //going back to google home page
            Thread.Sleep(2000);
            driver.Navigate().Forward();            //forwarding back to yahoo home page
            Thread.Sleep(2000);
            driver.Navigate().Back();               //going back to google home page
            Thread.Sleep(2000);
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));   //selecting the input search box
            searchinputtextbox.SendKeys("What's new for Diwali 2023?");             //enter the search term inside the search box
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));      //getting the google search button
            gsbutton.Click();                                                       //clicking the google search button
            Assert.AreEqual("What's new for Diwali 2023? - Google Search", driver.Title);   //checking the page is loaded properly
            Console.WriteLine("page change Test Passed");                                   //if the page is loaded properly test passed shown
            driver.Navigate().Refresh();                                            //refreshing the page
            driver.Close();                         //closing the current tab
        }

    }
}
