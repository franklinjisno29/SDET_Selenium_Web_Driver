using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit.PageObjects
{
    internal class Product
    {
        IWebDriver driver;
        public Product(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver)); ;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//a[text()='Black-2.50']")]
        public IWebElement? SizeClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement? AddToCartClick { get; set; }

        //Act
        public void ClickSize()
        {
            SizeClick?.Click();
        }
        public void ClickAddToCart()
        {
            AddToCartClick?.Click();
        }
        public string GetTitle()
        {
            string t = driver.Url;
            return t;
        }
        
    }
}
