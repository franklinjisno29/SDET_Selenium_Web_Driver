using Assignments;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


//14/11/23 assignment1
/*AHPTest aHP = new AHPTest();            //creating object of the amazon home page class
try
{
    aHP.InitializeChromeDriver();           //calling the function for opening the browser
    aHP.TitleTest();                        //calling function for title testing
    aHP.OrgTest();                          //calling the function for organisation testing
    aHP.Destruct();                         //calling the function for closing the tab
}
catch (AssertionException)
    {
    Console.WriteLine("Test Failed");       //if any test fails, this line will be displayed
}*/

//assignment2
Searchpage search = new();                  //creating the object for searchpage
try
{
    search.OpenBrowser();                   //calling the function for performing the operations
}
catch (AssertionException)
{
    Console.WriteLine("Test Failed");       //if any test fails, this line will be displayed
}