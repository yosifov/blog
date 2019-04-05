﻿namespace Blog.IntegrationTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestFixture]
    public class GetTests : BaseIntegrationTest
    {
        [Test]
        public async Task GetOkStatusCode()
        {
            //Arrange
            var response = await Client.GetAsync("/Article/List");
            response.EnsureSuccessStatusCode();

            //Act
            var responseAsString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task GetRegistrationForm()
        {
            //Arrange
            var response = await Client.GetAsync("/Account/Register");
            response.EnsureSuccessStatusCode();
            
            //Act
            var responseAsString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.That(responseAsString.Contains("Register"));
        }

        [Test]
        public async Task GetASingleArticle()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/Article/Details/1");
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + directoryPath + "/Article.json");

            //Act
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.That(responseAsString.Contains("Dulcy"));
        }
        
    }
}

