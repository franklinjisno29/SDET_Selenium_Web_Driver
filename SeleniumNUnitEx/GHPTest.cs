using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitEx
{
    [TestFixture]
    internal class GHPTest : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test Passed");
        }
        [Ignore("other")]
        [Test]
        [Order(20)]
        public void GSTest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptops");
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("page change Test Passed");
        }
        [Ignore("other")]
        [Test]
        public void AllLinkStatusTest()
        {
            List<IWebElement> alllinks = driver.FindElements(By.TagName("a")).ToList();
            foreach(var link in alllinks)
            {
                string url = link.GetAttribute("href");
                if(url==null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if(isworking)
                    {
                        Console.WriteLine(url + "is working");
                    }
                    else
                    {
                        Console.WriteLine(url + "is not working");

                    }
                }
            }
        }
    }
}
