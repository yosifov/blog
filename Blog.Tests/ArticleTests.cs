namespace Blog.Tests
{
    using Blog.Tests.Models;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.IO;

    [TestFixture]
    public class ArticleTests : BaseTest
    {
        [Test]
        [Order(5)]
        public void CreateArticleWithValidData()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/ArticleWithValidData.json");

            var article = Article.FromJson(File.ReadAllText(articlePath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.CreateButton.Click();
            createArticlePage.CreateArticleForm(article);

            List<string>  allArticleTitles = new List<string>();
            foreach (var title in homePage.AllArticleTitles)
            {
                allArticleTitles.Add(title.Text);
            }

            // Assert
            Assert.That(allArticleTitles.Contains(article.Title));

        }

        [Test]
        [Order(6)]
        public void DeleteArticleAsAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/ArticleWithValidData_DeleteTest.json");

            var article = Article.FromJson(File.ReadAllText(articlePath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.CreateButton.Click();
            createArticlePage.CreateArticleForm(article);

            IWebElement deleteArticle = driver.FindElement(By.LinkText(article.Title));
            deleteArticle.Click();

            articleMainPage.DeleteButton.Click();
            articleDeletePage.DeleteButton.Click();

            List<string> allArticleTitles = new List<string>();
            foreach (var title in homePage.AllArticleTitles)
            {
                allArticleTitles.Add(title.Text);
            }

            // Assert
            Assert.False(allArticleTitles.Contains(article.Title));
        }

        [Test]
        [Order(7)]
        public void DeleteArticleFromAnotherAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var secondUserPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginSecondUserWithValidCredentials.json");
            var secondUser = ActiveUser.FromJson(File.ReadAllText(secondUserPath));

            var articlePath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/ArticleWithValidData_DeleteTest.json");

            var article = Article.FromJson(File.ReadAllText(articlePath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.CreateButton.Click();
            createArticlePage.CreateArticleForm(article);

            homePage.LogOffButton.Click();
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(secondUser);

            IWebElement deleteArticle = driver.FindElement(By.LinkText(article.Title));
            deleteArticle.Click();

            articleMainPage.DeleteButton.Click();

            // Assert
            Assert.That(articleMainPage.ErrorMsg.Text.Contains("You can't delete article from another user."));
        }

        [Test]
        [Order(8)]
        public void EditArticleAsAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/ArticleWithValidData.json");

            var article = Article.FromJson(File.ReadAllText(articlePath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.CreateButton.Click();
            createArticlePage.CreateArticleForm(article);

            IWebElement editArticle = driver.FindElement(By.LinkText(article.Title));
            editArticle.Click();

            articleMainPage.EditButton.Click();
            articleEditPage.EditArticleForm();

            List<string> allArticleTitles = new List<string>();
            foreach (var title in homePage.AllArticleTitles)
            {
                allArticleTitles.Add(title.Text);
            }

            // Assert
            Assert.That(allArticleTitles.Contains(article.Title+" Edit"));
        }

        [Test]
        [Order(9)]
        public void EditArticleFromAnotherAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var secondUserPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginSecondUserWithValidCredentials.json");
            var secondUser = ActiveUser.FromJson(File.ReadAllText(secondUserPath));

            var articlePath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/ArticleWithValidData_DeleteTest.json");

            var article = Article.FromJson(File.ReadAllText(articlePath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.CreateButton.Click();
            createArticlePage.CreateArticleForm(article);

            homePage.LogOffButton.Click();
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(secondUser);

            IWebElement editArticle = driver.FindElement(By.LinkText(article.Title));
            editArticle.Click();

            articleMainPage.EditButton.Click();

            // Assert
            Assert.That(articleMainPage.ErrorMsg.Text.Contains("You can't edit article from another user."));
        }

        [Test]
        [Order(10)]
        [TestCase("ArticleWithInValidContent")]
        [TestCase("ArticleWithInValidTitle")]
        [TestCase("ArticleWithEmptyData")]
        public void CreateArticleWithInValidData(string jsonFileName)
        {
            // Arange
            var userPath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + "/../../../Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(
                Directory
                .GetCurrentDirectory() + $"/../../../Jsons/{jsonFileName}.json");

            var article = Article.FromJson(File.ReadAllText(articlePath));

            // Act
            driver.Navigate().GoToUrl(loginPage.Url);
            loginPage.LogIn(user);

            homePage.CreateButton.Click();
            createArticlePage.CreateArticleForm(article);


            // Assert
            string errorMessage = "";
            switch (jsonFileName)
            {
                case "ArticleWithInValidContent":
                    errorMessage = "The Content field is required.";
                    break;
                case "ArticleWithInValidTitle":
                    errorMessage = "The Title field is required.";
                    break;
                case "ArticleWithEmptyData":
                    errorMessage = "The Title field is required.\r\nThe Content field is required.";
                    break;
                default:
                    break;
            }
            Assert.That(createArticlePage.ErrorMsg.Text.Contains($"{errorMessage}"));
        }
    }
}
