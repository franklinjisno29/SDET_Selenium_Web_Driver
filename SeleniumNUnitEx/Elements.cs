using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitEx
{
    [TestFixture]
    internal class Elements:CoreCodes
    {
        [Ignore(" ")]
        [Test]
        public void TestElements()
        {
            IWebElement elements = driver.FindElement(By.XPath("//h5[text()='Elements']//parent::div"));
            elements.Click();
            IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']//parent::li"));
            cbmenu.Click();
            List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
            foreach(var item in expandcollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='commands')]"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);
        }
        [Ignore(" ")]
        [Test]
        public void TestFormElements()
        {
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(2000);
            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Doe");
            Thread.Sleep(2000);
            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("mail@ex");
            Thread.Sleep(2000);
            IWebElement genderField = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            genderField.Click();
            Thread.Sleep(2000);
            IWebElement mobileField = driver.FindElement(By.Id("userNumber"));
            mobileField.SendKeys("1234567890");
            Thread.Sleep(2000);
            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(2000);
            IWebElement domField = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectmonth = new SelectElement(domField);
            selectmonth.SelectByIndex(6);
            Thread.Sleep(2000);
            IWebElement doyField = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectyear = new SelectElement(doyField);
            selectyear.SelectByText("1994");
            Thread.Sleep(2000); 
            IWebElement dayField = driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--029']"));
            dayField.Click();
            Thread.Sleep(2000);
            IWebElement subjectField = driver.FindElement(By.Id("subjectsInput"));
            subjectField.SendKeys("Maths");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subjectField.SendKeys("Chemistry");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement hobbiesField = driver.FindElement(By.XPath("//input[@id='hobbies-checkbox-3']//following::label"));
            //label[text()='Sports']
            hobbiesField.Click();
            Thread.Sleep(2000);
            IWebElement pictureField = driver.FindElement(By.Id("uploadPicture"));
            pictureField.SendKeys("C:\\Users\\Administrator\\Pictures\\download.png");
            Thread.Sleep(2000); 
            IWebElement addressField = driver.FindElement(By.Id("currentAddress"));
            addressField.SendKeys("Thrissur, kerala");
            Thread.Sleep(2000);
        }
        [Ignore(" ")]
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("parent window handle:"+parentWindowHandle);
            IWebElement clickelement = driver.FindElement(By.Id("tabButton"));
            for(var i=0;i<3;i++)
            {
                clickelement.Click();
                Thread.Sleep(2000);
            }
            List<string> lstwindow = driver.WindowHandles.ToList();
            foreach(var handle in lstwindow)
            {
                Console.WriteLine("switching to window" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
                Console.WriteLine("navigating to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }
        [Ignore(" ")]
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is:" + alertText);
            Thread.Sleep(2000);
            simpleAlert.Accept();
            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(2000);
            element.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert is:"+confirmationAlert.Text);
            Thread.Sleep(2000);
            confirmationAlert.Dismiss();
            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(2000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert is " + promptAlert.Text);
            promptAlert.SendKeys("accepting the alert");
            Thread.Sleep(2000);
            promptAlert.Accept();
        }
    }
}
