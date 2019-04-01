namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;
    using Blog.Tests.Models;

    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public string Url => "https://demoprojectblog.azurewebsites.net/Account/Login";

        public void LogIn(ActiveUser user)
        {
            Email.SendKeys(user.Email);
            Password.SendKeys(user.CurrentPassword);
            LoginButton.Click();
        }
    }
}
