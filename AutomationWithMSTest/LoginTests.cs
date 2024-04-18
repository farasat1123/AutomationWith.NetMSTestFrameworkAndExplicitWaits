using AutomationWithMSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;


namespace SeleniumTests
{
    [TestClass]
    public class LoginTests : SeleniumSetup
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            InitializeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            QuitDriver();
        }

        [TestMethod]
        public void PositiveLoginTest1()
        {
            string url = "https://www.saucedemo.com/";
            string username = "standard_user";
            string password = "secret_sauce";

            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Name("user-name")).Displayed);
            IWebElement usernameField = driver.FindElement(By.Name("user-name"));
            usernameField.SendKeys(username);

            IWebElement passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.CssSelector("#login-button"));
            loginButton.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
            Assert.AreEqual("Swag Labs", driver.Title);
        }

        [TestMethod]
        public void PositiveLoginTest2()
        {
            string url = "https://www.saucedemo.com/";
            string username = "problem_user";
            string password = "secret_sauce";

            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Name("user-name")).Displayed);
            IWebElement usernameField = driver.FindElement(By.Name("user-name"));
            usernameField.SendKeys(username);

            IWebElement passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.CssSelector("#login-button"));
            loginButton.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
            Assert.AreEqual("Swag Labs", driver.Title);
        }

        [TestMethod]
        public void NegativeLoginTest1()
        {
            string url = "https://www.saucedemo.com/";
            string username = "locked_out_user";
            string password = "wrong_password";

            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Name("user-name")).Displayed);

            IWebElement usernameField = driver.FindElement(By.Name("user-name"));
            usernameField.SendKeys(username);

            IWebElement passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.CssSelector("#login-button"));
            loginButton.Click();

            // Custom explicit wait for error message visibility
            wait.Until(driver =>
            {
                try
                {
                    IWebElement errorMessage = driver.FindElement(By.CssSelector("[data-test='error']"));
                    return errorMessage.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            IWebElement errorMessage = driver.FindElement(By.CssSelector("[data-test='error']"));
            Assert.IsTrue(errorMessage.Displayed);
            Assert.IsTrue(errorMessage.Text.Contains("Epic sadface"));

        }


        [TestMethod]
        public void NegativeLoginTest2()
        {
            string url = "https://www.saucedemo.com/";
            string username = "standard_user";
            string password = "wrong_password";

            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Name("user-name")).Displayed);

            driver.FindElement(By.Name("user-name")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.CssSelector("#login-button")).Click();

            wait.Until(driver =>
            {
                try
                {
                    IWebElement errorMessage = driver.FindElement(By.CssSelector("[data-test='error']"));
                    return errorMessage.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            IWebElement errorMessage = driver.FindElement(By.CssSelector("[data-test='error']"));
            Assert.IsTrue(errorMessage.Displayed);
            Assert.IsTrue(errorMessage.Text.Contains("Epic sadface"));
        }



        [TestMethod]
        [Ignore("Skipping one negative test case")]
        public void NegativeLoginTest3_Skip()
        {
            Assert.IsTrue(true);
        }


    }
}