using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitEx
{
    [TestFixture]
    internal class ActionsElements : CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));
            Actions actions = new Actions(driver);
            Action mouseOverHomeLink = () => actions.MoveToElement(homelink).Build().Perform();
            Console.WriteLine("before: " + tdhomelink.GetCssValue("background-color"));
            mouseOverHomeLink.Invoke();
            Console.WriteLine("after: "+ tdhomelink.GetCssValue("background-color"));
        }
        [Test]
        public void multipleActionTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            Actions actions = new Actions(driver);
            Action uppercaseInput = () => actions
            .KeyDown(Keys.Shift).SendKeys(emailInput,"hello").KeyUp(Keys.Shift)
            .Build().Perform();
            uppercaseInput.Invoke();
            Console.WriteLine("text is:" + emailInput.GetAttribute("value"));
            Thread.Sleep(3000);
        }
    }
}
