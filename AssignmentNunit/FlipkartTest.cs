using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    internal class FlipkartTest : CoreCodes
    {
        [Test]
        public void SearchProduct()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement searchField = fluentWait.Until(d=>d.FindElement(By.XPath("//input[contains(@class,'Pke_EE')]")));
            searchField.SendKeys("laptops");
            IWebElement searchButton = fluentWait.Until(d=>d.FindElement(By.ClassName("_2iLD__")));
            searchButton.Click();
        }
    }
}
