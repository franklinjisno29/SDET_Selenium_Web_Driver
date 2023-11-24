using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.PageObjects
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
        [FindsBy(How = How.XPath, Using = "//ul[@class='sizeBox clearfix']//following::a[1]")]
        public IWebElement? SizeClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement? AddToCartClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='input_Special_2']")]
        public IWebElement? InQtyClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Remove')]")]
        public IWebElement? RemoveClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement? CloseClick { get; set; }

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
        public void ClickInQty()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value='';", InQtyClick);
            InQtyClick?.SendKeys("2");
        }
        public void ClickRemove()
        {
            RemoveClick?.Click();
        }
        public void ClickClose()
        {
            CloseClick?.Click();
        }
    }
}
