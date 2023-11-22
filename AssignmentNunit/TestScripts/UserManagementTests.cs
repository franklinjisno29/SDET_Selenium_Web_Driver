using AssignmentNunit.Utilities;
using AssignmentNunit.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AssignmentNunit.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void SearchProductFuncTest()
        {
            var homePage = new NaaptolHomePage(driver);
            var searchpage = homePage.TypeSearch("eyewear");
            Thread.Sleep(2000);
            var productpage = searchpage.ClickProduct();
            List<string> lstwindow = driver.WindowHandles.ToList();
            foreach (var handle in lstwindow)
            {
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
            productpage.ClickSize();
            productpage.ClickAddToCart();
            Thread.Sleep(2000);
            string urllink = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
            Assert.AreEqual(driver.FindElement(By.XPath("//a[contains(text(),'LRG4')]")).GetAttribute("href"), urllink);
        }
    }
}
