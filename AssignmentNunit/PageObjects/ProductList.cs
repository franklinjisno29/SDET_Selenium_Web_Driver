using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [FindsBy(How = How.XPath, Using = "//div[@pid='12612074']")]
        public IWebElement? ProductSelect { get; set; }

        //Act
        public Product ClickProduct()
        {
            ProductSelect?.Click();
            return new Product(driver);

        }
    }
}
