namespace Blog.Tests
{
    using Blog.Tests.Models;
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class PasswordTests : BaseTest
    {
        [Test]
        [Order(11)]
        [Category("UI")]
        public void ChangePasswordWithValidData()
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/ChangePasswordWithValidData.json");
            var userPathRestore = Path.GetFullPath(directoryPath + "/Jsons/ChangePasswordWithValidData_Restore.json");

            var user = ActiveUser.FromJson(File.ReadAllText(userPath));
            var userRestore = ActiveUser.FromJson(File.ReadAllText(userPathRestore));

            //var passwordChange = new SwapPasswordsAfterPasswordChange();
            //passwordChange.SwapPasswords(userPath);


            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);
            
            homePage.HelloButton.Click();
            profilePage.ChangePasswordButton.Click();
            profilePage.ChangePasswordForm(user);
            profilePage.SubmitButton.Click();

            //Restore original Password
            homePage.HelloButton.Click();
            profilePage.ChangePasswordButton.Click();
            profilePage.ChangePasswordForm(userRestore);
            profilePage.SubmitButton.Click();

            // Assert
            Assert.That(homePage.HelloButton.Displayed);
        }

        [Test]
        [Order(12)]
        [Category("UI")]
        [TestCase("ChangePasswordWithEmptyNewPassword")]
        [TestCase("ChangePasswordWithWrongConfirmationPassword")]
        public void ChangePasswordWithInvalidData(string jsonFileName)
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + $"/Jsons/{jsonFileName}.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.HelloButton.Click();
           
            profilePage.ChangePasswordButton.Click();
            
            profilePage.ChangePasswordForm(user);
            profilePage.SubmitButton.Click();

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
