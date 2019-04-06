namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class HomePage : BasePage
    {
        public IWebElement RegisterButton => Wait.Until(d => d.FindElement(By.Id("registerLink")));

        public IWebElement LogInButton => Wait.Until(d => d.FindElement(By.Id("loginLink")));

        public IWebElement CreateButton => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""logoutForm""]/ul/li[1]/a")));

        public IWebElement LogOffButton => Wait.Until(d => d.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")));

        //public IWebElement HelloButton => Wait.Until(d => d.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
        public IWebElement HelloButton => Wait.Until(d => d.FindElement(By.CssSelector("#logoutForm>ul>li:nth-child(2)>a")));

        public IWebElement FirstArticleLink => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a")));

        public IList<IWebElement> AllArticleTitles => Wait.Until(d => d.FindElements(By.TagName("h2")));

        public string HomePageTitle => Wait.Until(d => d.Title);
    }
}
