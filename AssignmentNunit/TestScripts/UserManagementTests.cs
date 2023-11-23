using AssignmentNunit.Utilities;
using AssignmentNunit.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AssignmentNunit.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        [TestCaseSource(nameof(productData))]

        public void SearchProductFuncTest(string pId)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            var homePage = new NaaptolHomePage(driver);
            var searchpage = homePage.TypeSearch("eyewear");
            Thread.Sleep(2000);
            var productpage = searchpage.ClickProduct(pId);
            List<string> lstwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lstwindow[1]);
            Thread.Sleep(2000);
            productpage.ClickSize();
            productpage.ClickAddToCart();
            string urllink = productpage.GetTitle();
            Thread.Sleep(2000);
            Assert.That(urllink, Is.EqualTo(driver.FindElement(By.XPath("//a[contains(text(),'LRG4')]")).GetAttribute("href")));
        }
        static object[] productData()
        {
            return new object[]
            {
                new object[]  { "5" }
            };
        }
    }
}
