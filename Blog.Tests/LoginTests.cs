﻿namespace Blog.Tests
{
    using Blog.Tests.Models;
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        [Order(3)]
        [TestCase("Login")]
        [TestCase("Logout")]
        public void LoginWithValidCredentials(string testCase)
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            // Assert
            switch (testCase)
            {
                case "Login":
                    Assert.That(homePage.HelloButton.Displayed);
                    break;
                case "Logout":
                    homePage.LogOffButton.Click();
                    Assert.That(homePage.LogInButton.Displayed);
                    break;
                default:
                    break;
            }
        }

        [Test]
        [Order(4)]
        public void LoginWithInvalidCredentials()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithInvalidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            // Assert
            Assert.That(loginPage.ErrorMsg.Text.Contains("Invalid login attempt."));
        }
    }
}