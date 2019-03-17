namespace Blog.Tests.Pages
{
    using Blog.Tests.Models;
    using OpenQA.Selenium;

    public partial class ArticleEditPage : BasePage
    {
        public ArticleEditPage(IWebDriver driver) : base(driver)
        { }

        public void EditArticleForm()
        {
            Title.SendKeys("Edit");
            Content.SendKeys("Edit");
            EditButton.Click();
        }
    }
}
