namespace Blog.IntegrationTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestFixture]
    public class PostTests : BaseIntegrationTest
    {
        [Test]
        [Category("Integration")]
        public async Task PostUserWithInvalidEmail_ShouldReturnInternalServerError()
        {
            //Arrange
            var expectedUser = new Users
            {
                Email = "lili",
                FullName = "lili",
                Password = "lili",
                ConfirmPassword = "lili"
            };
            var requestContent = new StringContent(expectedUser.ToJson());

            //Act
            var response = await Client.PostAsync("/Account/Register", requestContent);

            //Assert
            response.StatusCode.Should().Be(500);
        }
        
        [Test]
        [Category("Integration")]
        public async Task PostUserAlreadyRegistered_ShouldReturnInternalServerError()
        {
            //Arrange
            var expectedUser = new Users
            {
                Email = "lili@abv.bg",
                FullName = "lili",
                Password = "lili",
                ConfirmPassword = "lili"
            };
            var requestContent = new StringContent(expectedUser.ToJson());

            //Act
            var response = await Client.PostAsync("/Account/Register", requestContent);

            //Assert
            response.StatusCode.Should().Be(500);
        }

        [Test]
        [Category("Integration")]
        public async Task PostUserWithNoData_ShouldReturnInternalServerError()
        {
            //Arrange
            var expectedUser = new Users
            {
                Email = "",
                FullName = "",
                Password = "",
                ConfirmPassword = ""
            };
            var requestContent = new StringContent(expectedUser.ToJson());

            //Act
            var response = await Client.PostAsync("/Account/Register", requestContent);

            //Assert
            response.StatusCode.Should().Be(500);
        }

        [Test]
        [Category("Integration")]
        public async Task PostUserWithNoName_ShouldReturnInternalServerError()
        {
            //Arrange
            var expectedUser = new Users
            {
                Email = "lili@abv.bg",
                FullName = "",
                Password = "lili",
                ConfirmPassword = "lili"
            };
            var requestContent = new StringContent(expectedUser.ToJson());

            //Act
            var response = await Client.PostAsync("/Account/Register", requestContent);

            //Assert
            response.StatusCode.Should().Be(500);
        }

    }

}

