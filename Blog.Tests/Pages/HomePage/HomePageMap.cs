﻿namespace Blog.Tests.Pages
{
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        public IWebElement SignInButton => Wait.Until(d => d.FindElement(By.Id("registerLink")));

        public IWebElement LogInButton => Wait.Until(d => d.FindElement(By.Id("loginLink")));

        public IWebElement FirstArticleLink => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a")));

        public IWebElement HomePageTitle => Wait.Until(d => d.FindElement(By.TagName("title")));
    }
}
