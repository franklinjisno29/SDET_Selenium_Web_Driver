using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumEx
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            string title = driver.Title;
            Console.WriteLine("Title:{0}", title);
            Console.WriteLine("Title Length:{0}", driver.Title.Length);
            Assert.That(driver.Title.Contains("Amazon"));
            Console.WriteLine("Title Test Passed");
        }
        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.That(driver.Title.Contains("Amazon"));
            Console.WriteLine("logo click Test Passed");
        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Thread.Sleep(3000);
            Assert.That(driver.Title.Contains("mobiles")&&driver.Url.Contains("mobiles"));
            Console.WriteLine("search product Test Passed");
        }
        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);
        }
        public void TodaysDealTest()
        {
            IWebElement todaysdeals = driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null)
            {
                throw new NoSuchElementException("today's deals link not present");
            }
            todaysdeals.Click();
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("todays deal Test Passed");
        }
        public void SignInAccListTest()
        {
            IWebElement hellosign = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if (hellosign == null)
            { throw new NoSuchElementException("hello sign not present"); }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if (accountandlists == null)
            { throw new NoSuchElementException("account and list not present"); }
            Assert.That(hellosign.Text.Equals("Hello, sign in") && accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Hello sign in & account and list test passed");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"p_89/SAMSUNG\"]/span/a/div/label/i")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/SAMSUNG\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("samsung selected");
            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/i")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("apple selected");
        }
        public void SortBySelecttTest()
        {
            IWebElement sortby = driver.FindElement(By.ClassName("a-native-dropdown"));
            SelectElement sortbyselect = (SelectElement)sortby;
            sortbyselect.SelectByValue("1");
            Thread.Sleep(3000);
            Console.WriteLine(sortbyselect.SelectedOption);
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
