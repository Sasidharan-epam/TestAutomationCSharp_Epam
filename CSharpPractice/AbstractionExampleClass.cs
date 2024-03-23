using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace CSharpPractice
{
    public abstract class DriverInitialization
    {
        private IWebDriver Driver;

        public abstract void InitializeWebDriver(int choice);

        public void ExitWebDriver()
        {
            Driver.Close();
            Driver.Quit();
        }
    }

    public class ImplementedDriver : DriverInitialization
    {
        private IWebDriver webDriver;

        public override void InitializeWebDriver(int value)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("Initializing ChromeDriver");
                    webDriver = new ChromeDriver();
                    break;

                case 2:
                    Console.WriteLine("Initializing EdgeDriver");
                    webDriver = new EdgeDriver();
                    break;

                case 3:
                    Console.WriteLine("Initializing FireFoxDriver");
                    webDriver = new FirefoxDriver();
                    break;
            }
        }
    }

    public class TestDriverClass
    {
        private ImplementedDriver _implementedDriver = new ImplementedDriver();

        private void DriverActions()
        {
            _implementedDriver.InitializeWebDriver(1);
            _implementedDriver.ExitWebDriver();
        }
    }
}