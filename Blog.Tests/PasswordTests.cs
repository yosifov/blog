namespace Blog.Tests
{
    using Blog.Tests.Models;
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class PasswordTests : BaseTest
    {
        [Test]
        public void ChangePasswordWithValidData()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/ChangePasswordWithValidData.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);
            
            homePage.HelloButton.Click();
            profilePage.ChangePasswordButton.Click();
            profilePage.ChangePasswordForm(user);

            // Assert
            Assert.That(homePage.HelloButton.Displayed);
        }

        [Test]
        [TestCase("ChangePasswordWithEmptyNewPassword")]
        [TestCase("ChangePasswordWithWrongConfirmationPassword")]
        public void ChangePasswordWithInvalidData(string jsonFileName)
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + $"/../../../Jsons/{jsonFileName}.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.HelloButton.Click();
           
            profilePage.ChangePasswordButton.Click();
            
            profilePage.ChangePasswordForm(user);
            
            // Assert
            string errorMessage = "";
            switch (jsonFileName)
            {
                case "ChangePasswordWithEmptyNewPassword":
                    errorMessage = "The New password field is required.";
                    break;
                case "ChangePasswordWithWrongConfirmationPassword":
                    errorMessage = "The new password and confirmation password do not match.";
                    break;
                
                default:
                    break;
            }
            Assert.That(profilePage.ErrorMsg.Text.Contains($"{errorMessage}"));

        }
    }
}
