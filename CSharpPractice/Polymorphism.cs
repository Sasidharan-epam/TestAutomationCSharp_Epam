using System;

namespace CSharpPractice
{

    interface IDriver
    {
        void Click();
        void SendKeys();
    }

    public class ChromeDriver1 : IDriver
    {
        public void Click()
        {
            Console.WriteLine("Click from ChromeDriver");
        }
        public void SendKeys()
        {
            Console.WriteLine("SendKey from ChromeDriver");
        }
    }

    public class EdgeDriver1 : IDriver
    {
        public void Click()
        {
            Console.WriteLine("Click from EdgeDriver");
        }
        public void SendKeys()
        {
            Console.WriteLine("SendKey from EdgeDriver");
        }
    }

    class Polymorphism
    {
        public IDriver Driver;
        IDriver InitializeDriver(string BrowserChoice)
        {
            switch(BrowserChoice)
            {
                case "Chrome":
                    return Driver = new ChromeDriver1();
                    break;
                case "Edge":
                    return Driver = new EdgeDriver1();
                    break;
                default:
                    return new ChromeDriver1();
            }    
           
        }

        void NavigateToHomePage()
        {
            Driver.SendKeys();
            Driver.Click();
        }

    }


}
