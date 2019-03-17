namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class ArticleEditPage : BasePage
    {

        public IWebElement Title => Wait.Until(d => d.FindElement(By.Id("Title")));

        public IWebElement Content => Wait.Until(d => d.FindElement(By.Id("Content")));

        public IWebElement ErrorMsg => Wait.Until(d => d.FindElement(By.ClassName("validation-summary-errors")));

        public IWebElement EditButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/div/form/div[4]/div/input")));

        public IWebElement CancelButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/div/form/div[4]/div/a")));
    }
}
