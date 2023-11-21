using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitEx
{
    [TestFixture]
    internal class LinkedinTests:CoreCodes
    {
        [Test]
        [Author("Franklin","1@3.com")]
        [Description("check for valid login")]
        [Category("Regression Testing")]
        public void LoginTest()
        {
            //implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //explicit wait
            //WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(2));
            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            //IWebElement emailInput = wait.Until(d=>d.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));

            //fluent wait
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys("1@3.com");
            passwordInput.SendKeys("1234");
        }
        /*[Test, Author("Franklin", "1@3.com")]
        [Description("check for invalid login"), Category("Smoke Testing")]
        public void LoginTestWithInvalidCred()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys("1@3.com");
            passwordInput.SendKeys("1234");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            emailInput.SendKeys("2@3.com");
            passwordInput.SendKeys("2345");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            emailInput.SendKeys("3@3.com");
            passwordInput.SendKeys("3456");
        }
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }*/
        //[Test,Author("Jisno", "2@4.com")]
        //[Description("check for invalid login"),Category("Regression Testing")]
        //[TestCase("1@3.com", "1234")]
        //[TestCase("2@3.com", "2345")]
        //[TestCase("3@3.com", "3456")]
        //public void LoginTestWithInvalidCred(string email, string pwd)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "element not found";
        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
        //    emailInput.SendKeys(email); 
        //    passwordInput.SendKeys(pwd);
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);
        //}
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        [Test, Author("Jisno", "2@4.com")]
        [Description("check for invalid login"), Category("Regression Testing")]
        [TestCaseSource(nameof(invalidLoginData))]
        public void LoginTestWithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            TakeScreeshot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(3000);
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));

            ClearForm(emailInput);
            ClearForm(passwordInput);
        }
        static object[] invalidLoginData()
        {
            return new object[]
            {
                new object[]  { "1@3.com", "1234" },
                new object[] { "2@3.com", "2345" },
                new object[] { "3@3.com", "3456" }
            };
        }
        
    }
}
