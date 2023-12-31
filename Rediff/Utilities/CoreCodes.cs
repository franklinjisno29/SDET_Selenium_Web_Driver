﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver driver;
        public void ReadConfigSettings()
        {
            string currDir = Directory.GetParent(@"../../../").FullName; //getting the working directory
            properties = new Dictionary<string, string>();               //declaring the dictionary
            string filename = currDir + "/ConfigSettings/config.properties"; //taking the file from working directory
            string[] lines = File.ReadAllLines(filename);

            foreach(string line in lines)                               //for geting the file data even if there are whitespaces
            {
                if(!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using(var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void TakeScreeshot()
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot screenshot = its.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filePath = currDir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".png";
            screenshot.SaveAsFile(filePath);
            Console.WriteLine("taken screenshot");
        }
    }
}
