﻿using BunnyCart.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BCHomePage : CoreCodes
    {
        IWebDriver driver;
        public BCHomePage(IWebDriver? driver)                               
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//if the driver is null exception thrown
            PageFactory.InitElements(driver, this);//for optimizing the code we write this inside the constructor
        }

        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]//store the element inside the cache memory from page factory.
        private IWebElement? SearchText { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstNameText { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameText { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement? EmailText { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PassworText { get; set; }

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private IWebElement? ConfirmPasswordText { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberText { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title = 'Create an Account']")]
        private IWebElement? SignUpButton { get; set; }

        //Act
        public void ClickCreateAccountLink()
        {
            CreateAccountLink?.Click();
        }
        public void SignUp(string firstname, string lastname, string email, string password, string confirmpassword, string mobileno)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));
            FirstNameText?.SendKeys(firstname);
            LastNameText?.SendKeys(lastname);
            EmailText?.SendKeys(email);
            ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PassworText?.SendKeys(password);
            ConfirmPasswordText?.SendKeys(confirmpassword);
            ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumberText?.SendKeys(mobileno);
            Thread.Sleep(2000);
            SignUpButton?.Click();
        }
        

        public SearchResultPage TypeSearchText(string searchText)
        {
            if(searchText == null)
                throw new NoSuchElementException(nameof(searchText));
            SearchText?.SendKeys(searchText);
            SearchText?.SendKeys(Keys.Enter);
            return new SearchResultPage(driver);
        }
    }
}
