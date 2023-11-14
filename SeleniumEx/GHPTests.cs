using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumEx
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            string title = driver.Title;
            Console.WriteLine("Title:{0}",title);
            Console.WriteLine("Title Length:{0}",driver.Title.Length);
            Assert.AreEqual("Google", title);
            Console.WriteLine("Title Test Passed");
        }
        public void PageSourceandURLTest()
        {
            Console.WriteLine("PageSource Length:{0}", driver.PageSource.Length);
            Console.WriteLine("URL:{0}", driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("URL Test Passed");
        }
        public void GSTest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptops");
            Thread.Sleep(2000);
            //IWebElement gsbutton = driver.FindElement(By.Name("btnK"));
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("page change Test Passed");
        }
        public void GmaillinkTest()
        {
            driver.Navigate().Back();
            driver.Url = "https://www.google.com";
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Title.Contains("Gmail"));
            Console.WriteLine("gmail link text title Test Passed");
        }
        public void ImageTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("image link text Test Passed");
        }
        public void LocalisationTest()
        {
            driver.Navigate().Back();
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(2000);
            Assert.That(loc.Equals("India"));
            Console.WriteLine("loc Test Passed");
        }
        public void GAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a[contains(@href, 'youtube')]")).Click();
            Thread.Sleep(4000);
            Assert.That(driver.Title.Contains("Youtube"));
            Console.WriteLine("youtube test passed");
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
