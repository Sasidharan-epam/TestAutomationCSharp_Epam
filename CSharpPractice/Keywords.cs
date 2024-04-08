using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;

namespace CSharpAdvancedTasks
{
    /// <summary>
    /// Task 2- Summary of various keywords
    /// Task 3,4 - Exception handlings, throws and custom exception
    /// </summary>
    /// 

    //private, public and throws keywords
     class InitializeDriver
    {
        private IWebDriver Driver { get; }
        public InitializeDriver()
        {
            Driver = new EdgeDriver() ?? throw new NullReferenceException("Driver is not initiated");
        }


    }

    //keywords and Access modifiers
    static class Keywords
    {
        
        static void RightClickAndChooseMenuOption(this IWebElement element,IWebDriver driver)
        {
            Actions action = new Actions(driver);
            try
            {
                if (element.Displayed && element.Enabled)
                    action.ContextClick(element).Perform();
            }
            catch(NoSuchElementException)
            {
                if (driver is EdgeDriver)
                    throw new DriverServiceNotFoundException();
            }
            finally
            {
                Console.WriteLine("Cannot perform RightClick due to failed driver initialization");
            }
        }

        static void SearchAndClickMenuOption(this IWebElement element,IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.ContextClick(element).Perform();
            IList<IWebElement> elements = driver.FindElements(By.Name("options"));
            foreach(var item in elements)
            {
                try
                {
                    if (item.Text.Contains("In Stock"))
                        element.Click();
                }
                catch(OutofStockException e)
                {
                    Console.WriteLine("The selected items is currently too less for delivery quantity " + e.StockItems);
                }
            }
            
        }
    }

    //Custom Exception
    public class OutofStockException: Exception
    {
        public int StockItems { get; set; }
        public OutofStockException(int availableStock)
        {
            StockItems = availableStock;
        }

        public override string Message => base.Message;
    }

}
