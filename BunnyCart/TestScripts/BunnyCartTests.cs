using BunnyCart.Utilities;
using BunnyCart.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V117.Debugger;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]

        public void SignUpTest()
        {
            //BCHomePage bchp1 = new BCHomePage(driver);
            //bchp.ClickCreateAccountLink();
            //Thread.Sleep(2000);
            //try
            //{
            //    Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text, Is.EqualTo("Create an Account"));
            //    bchp.SignUp("John", "Doe", "1@3.com", "1234", "1234", "9876543212");
            //    //Assert.That("", "");
            //}
            //catch(AssertionException)
            //{
            //    Console.WriteLine("SignUp Failed");
            //}

            BCHomePage bchp = new BCHomePage(driver);

            bchp.ClickCreateAccountLink();
            Thread.Sleep(2000);

            Assert.That(driver?.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text, Is.EqualTo("Create an Account"));

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "SignUp";

            List<SignUpData> signUpDataList = ExcelUtils.ReadSignUpData(excelFilePath, sheetName);

            foreach (var signUpData in signUpDataList)
            {

                string? firstName = signUpData?.FirstName;
                string? lastName = signUpData?.LastName;
                string? email = signUpData?.Email;
                string? pwd = signUpData?.Password;
                string? conpwd = signUpData?.ConfirmPassword;
                string? mbno = signUpData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);
                // Assert.That(""."")

            }

        }
    }
        
}
