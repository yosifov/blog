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
        protected string directoryPath;

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://demoprojectblog.azurewebsites.net");
            var test = Guid.Empty.ToString();


            //Path to directory depending of the Domain Name (local or azure)
            if (Environment.UserDomainName == "fv-az608") //This is the Domain Name of Azure
            {
                directoryPath = "";
            }
            else
            {
                directoryPath = "/../../..";
            }
        }

        public Fixture Fixture => new Fixture();

    }
}

