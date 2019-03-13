namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class ProfilePage : BasePage
    {
        public IWebElement ChangePasswordButton => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/dl/dd/a")));

        public IWebElement OldPassword => Wait.Until(d => d.FindElement(By.Id("OldPassword")));

        public IWebElement NewPassword => Wait.Until(d => d.FindElement(By.Id("NewPassword")));

        public IWebElement ConfirmPassword => Wait.Until(d => d.FindElement(By.Id("ConfirmPassword")));

        public IWebElement SubmitButton => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/div/input")));

        public IWebElement SuccessMsg => Wait.Until(d => d.FindElement(By.ClassName("text-success")));

        public IWebElement ErrorMsg => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
    }
}
