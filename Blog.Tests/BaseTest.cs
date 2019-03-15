namespace Blog.Tests
{
    using Blog.Tests.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage homePage;
        protected LoginPage loginPage;
        protected RegistrationPage registrationPage;
        protected ProfilePage profilePage;
        protected CreateArticlePage createArticlePage;

        [SetUp]
        public void SetUp()
        {
            // Driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Maximize The Window
            driver.Manage().Window.Maximize();

            // Home Page
            homePage = new HomePage(driver);

            // Login Page
            loginPage = new LoginPage(driver);

            // Registration Page
            registrationPage = new RegistrationPage(driver);

            // Profile Page
            profilePage = new ProfilePage(driver);

            // Create Article Page
            createArticlePage = new CreateArticlePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
