using BunnyCart.Utilities;
using BunnyCart.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V117.Debugger;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]

        public void SignUpTest()
        {
            BCHomePage bchp = new BCHomePage(driver);
            bchp.ClickCreateAccountLink();
            Thread.Sleep(2000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text, Is.EqualTo("Create an Account"));
                bchp.SignUp("John", "Doe", "1@3.com", "1234", "1234", "9876543212");
                //Assert.That("", "");
            }
            catch(AssertionException)
            {
                Console.WriteLine("SignUp Failed");
            }   
        }
        
    }
}
