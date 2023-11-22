using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using AssignmentNunit.Utilities;

namespace AssignmentNunit
{
    internal class NaaptolTests : CoreCodes
    {
        [Test]
        [Order(0)]
        public void SearchProduct()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement searchField = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='header_search_text']")));
            searchField.SendKeys("eyewear");
            searchField.SendKeys(Keys.Enter);
        }
        [Test]
        [Order(1)]
        [TestCaseSource(nameof(productData))]

        public void AddToCart(string pId)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//div[@id='productItem"+ pId +"']")));
            IWebElement productField = fluentWait.Until(d => d.FindElement(By.XPath("//div[@id='productItem"+ pId+"']")));
            productField.Click();
            List<string> lstwindow = driver.WindowHandles.ToList();
            foreach (var handle in lstwindow)
            {
                driver.SwitchTo().Window(handle); 
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            IWebElement sizeButton = fluentWait.Until(d => d.FindElement(By.XPath("//a[text()='Black-2.50']")));
            sizeButton.Click();
            IWebElement addToCartButton = fluentWait.Until(d => d.FindElement(By.XPath("//a[@id='cart-panel-button-0']")));
            addToCartButton.Click();
            Thread.Sleep(2000);
        }
        static object[] productData()
        {
            return new object[]
            {
                new object[]  { "5" }
            };
        }
        [Test]
        [Order(2)]
        public void ViewCart()
        {
            string title = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
            Assert.AreEqual(driver.FindElement(By.XPath("//a[contains(text(),'LRG4')]")).GetAttribute("href"),title);
        }
    }
}
