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
            Title.SendKeys(" This Article Title Was Edited");
            Content.SendKeys(" This Article Context Was Edited");
            EditButton.Click();
        }
    }
}
