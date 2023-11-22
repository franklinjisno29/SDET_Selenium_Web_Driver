using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : CoreCodes
    {
        //Asserts
        //[Test, Order(1), Category("Smoke Test")]
        //public void CreateAccountLinkTest()
        //{
        //    var homePage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    homePage.CreateAccountLinkClick();
        //    Assert.That(driver.Url.Contains("register"));
        //}
        //[Test, Order(2), Category("Smoke Test")]
        //public void SignInLinkTest()
        //{
        //    var homePage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    homePage.SignInLinkClick();
        //    Assert.That(driver.Url.Contains("login"));
        //}
        [Test, Order(1), Category("Regression Test")]
        public void CreateAccountFuncTest()
        {
            var homePage = new RediffHomePage(driver);
            if(!driver.Url.Equals("https://www.rediff.com/"))
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            var createaccountpage = homePage.CreateAccountClick();
            Thread.Sleep(10000);
            createaccountpage.TypeFullName("John Doe");
            createaccountpage.TypeRediffMail("1@3.com");
            createaccountpage.ClickCheckAvailabilitybtn();
            Thread.Sleep(3000);
            createaccountpage.ClickCreateMyAccountbtn();
        }
        [Test, Order(1), Category("Regression Test")]
        public void SignInFuncTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            var signinpage = homePage.SignInLinkClick();
            Thread.Sleep(10000);
            signinpage.TypeUserName("user");
            signinpage.TypePassword("passwrd");
            signinpage.ClickRememberMeCheckbox();
            Assert.False(signinpage?.RememberMeCheckbox?.Selected);
            Thread.Sleep(3000);
            signinpage?.ClickSignIn();
        }
    }
}
