using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumEx;


GHPTests ghp = new GHPTests();
List<string> drivers = new List<string>();
drivers.Add("EdgeDriver()");
drivers.Add("ChromeDriver()");

foreach (var d in drivers)
{
    switch(d)
    {
        case "EdgeDriver()":
            ghp.InitializeChromeDriver();   break;
        case "ChromeDriver()":
            ghp.InitializeEdgeDriver(); break;
    }
    try
    {
        //ghp.TitleTest();
        //ghp.PageSourceandURLTest();
        //ghp.GSTest();
        //ghp.GmaillinkTest();
        //ghp.ImageTest();
        //ghp.LocalisationTest();
        ghp.GAppYoutubeTest();
    }
    catch (AssertionException ex)
    {
        Console.WriteLine("Test Failed");
        Console.WriteLine(ex.Message);

    }
    ghp.Destruct();
}