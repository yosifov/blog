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
        [Category("UI")]
        public void CreateArticleWithValidData()
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(directoryPath + "/Jsons/ArticleWithValidData.json");

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
        [Category("UI")]
        public void DeleteArticleAsAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(directoryPath + "/Jsons/ArticleWithValidData_DeleteTest.json");

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
            Assert.False(allArticleTitles.Contains(article.Title),"The article is still here: " + article.Title);
        }

        [Test]
        [Order(7)]
        [Category("UI")]
        public void DeleteArticleFromAnotherAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var secondUserPath = Path.GetFullPath(directoryPath + "/Jsons/LoginSecondUserWithValidCredentials.json");
            var secondUser = ActiveUser.FromJson(File.ReadAllText(secondUserPath));

            var articlePath = Path.GetFullPath(directoryPath + "/Jsons/ArticleWithValidData_DeleteTest_AnotherAuthor.json");

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
        [Category("UI")]
        public void EditArticleAsAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(directoryPath + "/Jsons/ArticleWithValidData.json");

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
            Assert.That(allArticleTitles.Contains(article.Title+ " This Article Title Was Edited"));
        }

        [Test]
        [Order(9)]
        [Category("UI")]
        public void EditArticleFromAnotherAuthor()
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var secondUserPath = Path.GetFullPath(directoryPath + "/Jsons/LoginSecondUserWithValidCredentials.json");
            var secondUser = ActiveUser.FromJson(File.ReadAllText(secondUserPath));

            var articlePath = Path.GetFullPath(directoryPath + "/Jsons/ArticleWithValidData_EditTest_AnotherAuthor.json");

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
        [Category("UI")]
        [TestCase("ArticleWithInValidContent")]
        [TestCase("ArticleWithInValidTitle")]
        [TestCase("ArticleWithEmptyData")]
        public void CreateArticleWithInValidData(string jsonFileName)
        {
            // Arange
            var userPath = Path.GetFullPath(directoryPath + "/Jsons/LoginUserWithValidCredentials.json");
            var user = ActiveUser.FromJson(File.ReadAllText(userPath));

            var articlePath = Path.GetFullPath(directoryPath + $"/Jsons/{jsonFileName}.json");

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
