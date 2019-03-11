namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        public IWebElement SignInButton => Wait.Until(d => d.FindElement(By.Id("registerLink")));

        public IWebElement LogInButton => Wait.Until(d => d.FindElement(By.Id("loginLink")));

        public IWebElement HomePageTitle => Wait.Until(d => d.FindElement(By.TagName("title")));
    }
}
