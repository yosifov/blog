namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class LoginPage : BasePage
    {
        public IWebElement Email => Wait.Until(d => d.FindElement(By.Id("Email")));

        public IWebElement Password => Wait.Until(d => d.FindElement(By.Id("Password")));

        public IWebElement RememberMe => Wait.Until(d => d.FindElement(By.Id("RememberMe")));

        public IWebElement LoginButton => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")));

        public IWebElement ErrorMsg => Wait.Until(d => d.FindElement(By.ClassName("validation-summary-errors")));

        public IWebElement LoginPageHeader => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/h2")));
    }
}
