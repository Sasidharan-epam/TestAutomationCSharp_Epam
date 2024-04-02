using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharpPractice
{
    /// <summary>
    /// Task 7,9 - Method overloading, Access modifiers
    /// </summary>

    //Static class and static driver initialization
    public static class WebDriver
    {
        static IWebDriver _Driver;
        
        public static IWebDriver Initialize()
        {
           return  _Driver = new ChromeDriver();
        }
    }

    //BasePage for inheritance 
    public class BasePage
    {
        //throw exception with message
        public static IWebDriver CurrentDriver => WebDriver.Initialize() ?? throw new NullReferenceException("Driver not initialized");

        private WebDriverWait wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(60));

        protected void NavigatetoHomePage()
        {
            // try catch finally
            try
            {
                CurrentDriver.Navigate().GoToUrl("SampleURL");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                throw new DriverServiceNotFoundException("ChromeDriver not initialized,check driver version compatibility with current browser");
            }
            
        }

        //WaitUntill method overloading
        protected bool WaitUntill(Func<IWebDriver,bool> condition)
        {
            return wait.Until(condition);
        }

        protected IWebElement WaitUntill(Func<IWebDriver, IWebElement> condition)
        {
            return wait.Until(condition);
        }
    }

    //Inherited Sub Class
    //Access to only protected and public methods
    internal class LandingPage : BasePage
    {
        
        void ValidateLandingpage()
        {
           
            IWebElement TestIcon = CurrentDriver.FindElement(By.Id("IconID"));
            //method overloading for different signatures
            WaitUntill(x => TestIcon.Displayed);
            WaitUntill(x => TestIcon.FindElement(By.LinkText("LinkTestToFind")));
        }
    }

    
}
