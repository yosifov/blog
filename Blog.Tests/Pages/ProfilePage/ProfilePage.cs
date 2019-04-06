namespace Blog.Tests.Pages
{
    using Blog.Tests.Models;
    using OpenQA.Selenium;

    public partial class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver) : base(driver)
        { }

        public string Url = "https://demoprojectblog.azurewebsites.net/Manage";

        public void ChangePasswordForm(ActiveUser user)
        {
            OldPassword.SendKeys(user.CurrentPassword);
            NewPassword.SendKeys(user.NewPassword);
            ConfirmPassword.SendKeys(user.ConfirmPassword);
        }
    }
}
