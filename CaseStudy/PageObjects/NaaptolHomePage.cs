using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver driver;
        public NaaptolHomePage(IWebDriver? driver)                               
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//if the driver is null exception thrown
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[@id='header_search_text']")]
        public IWebElement? SearchText { get; set; }

        //Act
        public ProductList TypeSearch(string searchTerm)
        {
            SearchText?.SendKeys(searchTerm);
            SearchText?.SendKeys(Keys.Enter);
            return new ProductList(driver);
        }
    }
}
