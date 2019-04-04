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
        public async Task PostUserWithInvalidEmail_ShouldReturnInternalServerError()
        {
            //Arrange
            var expectedUser = new Users
            {
                Email = "",
                FullName = "lili",
                Password = "lili",
                ConfirmPassword = "lili"
            };
            var requestContent = new StringContent(expectedUser.ToJson());

            //Act
            var response = await Client.PostAsync("/Account/Register", requestContent);
            response.StatusCode.Should().Be(500);
        }

        [Test]
        public async Task PostUserAlreadyRegister_ShouldReturnInternalServerError()
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
            response.StatusCode.Should().Be(500);
        }
    
        [Test]
        public async Task PostNewArticleWithNoData_ShouldReturnInternalServerError()
        {
            var response = await Client.PostAsync("/Article/Create", null);
            response.StatusCode.Should().Be(500);
        }

    }
}
