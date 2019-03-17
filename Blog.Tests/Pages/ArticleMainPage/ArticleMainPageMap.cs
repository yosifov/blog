namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class ArticleMainPage : BasePage
    {

        public IWebElement EditButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/article/footer/a[1]")));

        public IWebElement DeleteButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/article/footer/a[2]")));

        public IWebElement CancelButton => Wait.Until(d => d.FindElement(By.XPath(@"/html/body/div[2]/div/article/footer/a[3]")));

        public IWebElement ErrorMsg => Wait.Until(d => d.FindElement(By.ClassName("validation-summary-errors")));
    }
}
