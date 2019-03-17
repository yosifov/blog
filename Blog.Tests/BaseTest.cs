namespace Blog.Tests
{
    using Blog.Tests.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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

            // Article Main Page
            articleMainPage = new ArticleMainPage(driver);

            // Article Delete Page
            articleDeletePage = new ArticleDeletePage(driver);

            // Article Edit Page
            articleEditPage = new ArticleEditPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
