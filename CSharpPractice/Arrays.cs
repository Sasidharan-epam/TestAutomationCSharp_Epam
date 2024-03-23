using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSharpPractice
{
    //Enum for ElementStates
    public enum ElementStates
    {
        Enabled,
        Displayed,
        Selected,
        
    }

    //Sample array,arraylist examples
    class Arrays
    {
        IWebDriver Driver = new ChromeDriver();

        IList<IWebElement> ElementsList => Driver.FindElements(By.XPath("DynamicXpathHere"));
        ArrayList DisplayedElements = new ArrayList();
        ArrayList EnabledElements = new ArrayList();
        ArrayList SelectedElements = new ArrayList();

        public void ArrayMethod()
        {
            IWebElement[] ElementArray = new IWebElement[] { };
            for(int i=0; i<= ElementsList.Count;i++)
            {
                ElementArray.SetValue(ElementsList[i],i);
            }
            
            for(int j=0; j< ElementArray.Length;j++)
            {
                if (ElementArray[j].Displayed)
                    DisplayedElements.Add(ElementArray[j]);
                else if (ElementArray[j].Enabled)
                    EnabledElements.Add(ElementArray[j]);
                else if (ElementArray[j].Selected)
                    SelectedElements.Add(ElementArray[j]);
            }
            DisplayedElements.Sort();
            foreach (var value in DisplayedElements)
                Console.WriteLine(value.ToString());
        }
    }
}
