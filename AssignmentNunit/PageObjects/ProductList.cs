using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit.PageObjects
{
    internal class ProductList
    {
        IWebDriver driver;
        public ProductList(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        //[FindsBy(How = How.XPath, Using = "//div[@id='productItem" + pId + "']")]
        //public IWebElement? ProductSelect { get; set; }

        //Act
        public IWebElement GetProductSelect(string pId)
        {
            return driver.FindElement(By.XPath("//div[@id='productItem" + pId + "']"));
        }
        public Product ClickProduct(string pId)
        {
            GetProductSelect(pId)?.Click();
            return new Product(driver);

        }
    }
}
