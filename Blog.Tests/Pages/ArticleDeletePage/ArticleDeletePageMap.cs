namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class ArticleDeletePage : BasePage
    {
        public IWebElement DeleteButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/div/form/div[3]/div/input")));

        public IWebElement CancelButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/div/form/div[3]/div/a")));
    }
}
