namespace Blog.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Threading;

    [TestFixture]
    public class BaseTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            // Driver
            driver = new ChromeDriver();

            // Maximize The Window
            driver.Manage().Window.Maximize();

            // Home Page
            homePage = new HomePage(driver);

            // Login Page
            loginPage = new LoginPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
