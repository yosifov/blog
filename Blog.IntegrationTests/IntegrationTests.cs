namespace IntegrationTests
{
    using Blog.IntegrationTests;
    using NUnit.Framework;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestFixture]
    public class IntegrationTests : BaseIntegrationTest
    {

        [Test]
        public async Task GetOkStatusCode()
        {
            var response = await Client.GetAsync("/Article/List");

            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task RenderRegistrationForm()
        {
            var response = await Client.GetAsync("/Account/Register");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.That(responseAsString.Contains("Register"));

        }

        [Test]
        public async Task GetASingleArticle()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/Article/Details/5");
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../Article.json");


            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.That(responseAsString.Contains("Dulcy"));

        }
    }
}

