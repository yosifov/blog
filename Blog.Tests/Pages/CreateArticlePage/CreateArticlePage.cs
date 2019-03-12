namespace Blog.Tests.Pages
{
    using Blog.Tests.Models;
    using OpenQA.Selenium;

    public partial class CreateArticlePage : BasePage
    {
        public CreateArticlePage(IWebDriver driver) : base(driver)
        { }

        public void CreateArticleForm(Article article)
        {
            Title.SendKeys(article.Title);
            Content.SendKeys(article.Content);
            CreateButton.Click();
        }
    }
}
