using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    internal class FlipkartTest : CoreCodes
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
            IWebElement searchField = fluentWait.Until(d=>d.FindElement(By.XPath("//input[contains(@class,'Pke_EE')]")));
            searchField.SendKeys("laptops");
            searchField.SendKeys(Keys.Enter);
        }
        [Test]
        [Order(1)]
        public void AddToCart()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement productField = fluentWait.Until(d => d.FindElement(By.XPath("//div[@class='_2kHMtA'][1]")));
            productField.Click();
            List<string> lstwindow = driver.WindowHandles.ToList();
            foreach (var handle in lstwindow)
            {
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);
            IWebElement addToCartButton = fluentWait.Until(d => d.FindElement(By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']")));
            addToCartButton.Click();
            Thread.Sleep(2000);
        }
    }
}
