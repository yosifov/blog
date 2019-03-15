namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class RegistrationPage : BasePage
    {
        public IWebElement Email => Wait.Until(d => d.FindElement(By.Id("Email")));

        public IWebElement FullName => Wait.Until(d => d.FindElement(By.Id("FullName")));

        public IWebElement Password => Wait.Until(d => d.FindElement(By.Id("Password")));

        public IWebElement ConfirmPassword => Wait.Until(d => d.FindElement(By.Id("ConfirmPassword")));

        public IWebElement RegisterButton => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")));

        public IWebElement ErrorMsg => Wait.Until(d => d.FindElement(By.ClassName("validation-summary-errors")));

        public IWebElement RegisterPageHeader => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/h2")));
    }
}
