namespace Blog.Tests
{
    using Blog.Tests.Pages;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage homePage;
        protected LoginPage loginPage;
        protected RegistrationPage registrationPage;
        protected ProfilePage profilePage;
        protected CreateArticlePage createArticlePage;
        protected ArticleMainPage articleMainPage;
        protected ArticleDeletePage articleDeletePage;
        protected ArticleEditPage articleEditPage;
        protected string directoryPath;

        [SetUp]
        public void SetUp()
        {
            // Driver
            driver = GetChromeDriver();

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

            // Article Main Page
            articleMainPage = new ArticleMainPage(driver);

            // Article Delete Page
            articleDeletePage = new ArticleDeletePage(driver);

            // Article Edit Page
            articleEditPage = new ArticleEditPage(driver);

            //Path to directory depending of the Domain Name (local or azure)
            if (Environment.UserDomainName == "WARLUS" || Environment.UserDomainName == "KAMEN" || Environment.UserDomainName == "GAS_MT_MACHINE") //On local machine
            {
                directoryPath = Directory.GetCurrentDirectory() + "/../../..";
            }
            else // On azure
            {
                directoryPath = Directory.GetCurrentDirectory();
            }

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var testname = TestContext.CurrentContext.Test.Name
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("\"", "");
                var path = Path.GetFullPath(directoryPath+@"\Screenshots\") +
                                      testname + ".png";
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);

                TestContext.AddTestAttachment(path);
            }

            driver.Quit();
        }

        private RemoteWebDriver GetChromeDriver()
        {
            var path = Environment.GetEnvironmentVariable("ChromeWebDriver", EnvironmentVariableTarget.Machine);
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
           
            if (Environment.UserDomainName == "fv-az608") //This is the Domain Name of Azure
            {
                options.AddArguments("headless"); //Run headless on Azure
            }

            if (!string.IsNullOrWhiteSpace(path))
            {
                return new ChromeDriver(path, options, TimeSpan.FromSeconds(30));
            }
            else
            {
                return new ChromeDriver(options);
            }
        }

    }
}
