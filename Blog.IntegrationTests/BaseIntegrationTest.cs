namespace Blog.IntegrationTests
{
    using AutoFixture;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Net.Http;

    public class BaseIntegrationTest
    {
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:60634");

        }

        public Fixture Fixture => new Fixture();

       
    }
}

