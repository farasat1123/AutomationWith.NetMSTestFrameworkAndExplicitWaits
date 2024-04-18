using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWithMSTest
{
    public class SeleniumSetup
    {
        protected static IWebDriver driver;

        public static void InitializeDriver()
        {
            // Specify the path to the ChromeDriver executable
          //  string chromeDriverPath = @"C:\Users\Farasat Aziz\source\repos\AutomationWithMSTest\AutomationWithMSTest";

            // Initialize the ChromeDriver with the specified path
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public static void QuitDriver()
        {
            driver.Quit();
        }
    }

}