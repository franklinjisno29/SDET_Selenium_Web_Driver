using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class CreateAccountPage
    {
        IWebDriver driver;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.CssSelector, Using = "//input[contains(@name,'name')]")]
        public IWebElement? FullNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'login')]")]
        public IWebElement? RediffMailText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnchkava')]")]
        public IWebElement? CheckAvailabilityBtn { get; set; }

        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement? CreateMyAccountBtn { get; set; }

        //Act
        public void TypeFullName(string fullname)
        {
            FullNameText?.SendKeys(fullname);
        }
        public void TypeRediffMail(string email)
        {
            RediffMailText?.SendKeys(email);
        }
        public void ClickCheckAvailabilitybtn()
        {
            CheckAvailabilityBtn?.Click();
        }
        public void ClickCreateMyAccountbtn()
        {
            CreateMyAccountBtn?.Click();
        }
        public void ClearFullName()
        {
            FullNameText?.Clear();
        }
        public void ClearRediffMail()
        {
            RediffMailText?.Clear();
        }
    }
}
