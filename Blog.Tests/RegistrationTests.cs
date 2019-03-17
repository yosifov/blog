﻿namespace Blog.Tests
{
    using Blog.Tests.Models;
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class RegistrationTests : BaseTest
    {
        [Test]
        [Order(1)]
        public void RegisterUserWithValidData()
        {
            // Arrange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/RegistrationUserWithValidData.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(homePage.BaseUrl);
            homePage.RegisterButton.Click();

            registrationPage.FillForm(user);
            registrationPage.RegisterButton.Click();

            // Assert
            Assert.That(homePage.HomePageTitle.Contains("List - My ASP.NET Application"));
        }

        [Test]
        [Order(2)]
        [TestCase("RegisterInvalidEmail")]
        [TestCase("RegisterEmptyData")]
        [TestCase("RegisterInvalidConfirmationPassword")]
        [TestCase("RegisterExistingEmail")]
        public void RegisterUserWithInvalidData(string jsonFileName)
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + $"/../../../Jsons/{jsonFileName}.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(registrationPage.Url);
            registrationPage.FillForm(user);
            registrationPage.RegisterButton.Click();

            // Assert
            string errorMessage = "";
            switch (jsonFileName)
            {
                case "RegisterInvalidEmail":
                    errorMessage = "The Email field is not a valid e-mail address.";
                    break;
                case "RegisterEmptyData":
                    errorMessage = "The Email field is required.";
                    break;
                case "RegisterInvalidConfirmationPassword":
                    errorMessage = "The password and confirmation password do not match.";
                    break;
                case "RegisterExistingEmail":
                    errorMessage = "The Email field already exist.";
                    break;
                default:
                    break;
            }
            Assert.That(registrationPage.ErrorMsg.Text.Contains($"{errorMessage}"));
        }
    }
}
