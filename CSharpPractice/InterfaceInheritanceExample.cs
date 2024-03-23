using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharpPractice
{
     interface IWebPage
    {
        string PageTitle { get; }
        void PageNavigation();

    }

    public abstract class BaseWebPage
    {
        public abstract void PageLoading();
    }

    class HomePage : BaseWebPage, IWebPage
    {
        IWebDriver Driver;
        public HomePage(IWebDriver driver)
        {
            Driver = new ChromeDriver();
        }

        
        public string PageTitle => Driver.Title;


        public void PageNavigation()
        {
            Driver.Navigate().Forward();
            Driver.Navigate().Back();
        }

        public override void PageLoading()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            wait.Until(x => Driver.Title.Equals(PageTitle));
        }




    }
}
