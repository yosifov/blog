namespace Blog.Tests
{
    using Blog.Tests.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Threading;

    [TestFixture]
    public class RegistrationTests : BaseTest
    {
        [Test]
        public void RegisterUserWithValidData()
        {
            driver.Navigate().GoToUrl(homePage.BaseUrl);
            homePage.RegisterButton.Click();

            // TODO
        }
    }
}
