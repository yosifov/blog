namespace Blog.IntegrationTests
{
    using AutoFixture;
    using NUnit.Framework;
    using System;
    using System.IO;
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
            if (Environment.UserDomainName == "WARLUS" || Environment.UserDomainName == "KAMEN" || Environment.UserDomainName == "GAS_MT_MACHINE") //On local machine
            {
                directoryPath = Directory.GetCurrentDirectory() + "/../../..";
            }
            else // On azure
            {
                directoryPath = Directory.GetCurrentDirectory();
            }
        }

        public Fixture Fixture => new Fixture();

    }
}

