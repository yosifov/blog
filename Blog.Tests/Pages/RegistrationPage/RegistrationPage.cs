namespace Blog.Tests.Pages
{
    using Blog.Tests.Models;
    using OpenQA.Selenium;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        { }

        public string Url => "https://demoprojectblog.azurewebsites.net/Account/Register";

        public void FillForm(RegistrationUser user)
        {
            Email.SendKeys(user.Email);
            FullName.SendKeys(user.FullName);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(user.ConfirmPassword);
        }
    }
}
