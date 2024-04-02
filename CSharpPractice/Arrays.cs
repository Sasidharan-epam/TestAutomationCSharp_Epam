using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSharpPractice
{
    /// <summary>
    /// Task 5,12- Enums, Arrays
    /// </summary>
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
        int[] numbers = new int[5];
        private WebElement[] RowsData = new WebElement[20];

        public void WriteArray()
        {
            for(int i=0; i< RowsData.Length; i++)
            {
                RowsData[i] = (WebElement)Driver.FindElement(By.Id(""));
            }
        }

        public WebElement[] ReadArray()
        {
            WebElement[] Data = new WebElement[RowsData.Length];
            foreach(var data in RowsData)
            {
                if (data.Equals(ElementStates.Displayed))
                    RowsData.CopyTo(Data, 0);
            }
            return Data;
        }



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
                if (ElementArray[j].Equals(ElementStates.Displayed))
                    DisplayedElements.Add(ElementArray[j]);
                else if (ElementArray[j].Equals(ElementStates.Enabled))
                    EnabledElements.Add(ElementArray[j]);
                else if (ElementArray[j].Equals(ElementStates.Selected))
                    SelectedElements.Add(ElementArray[j]);
            }
            DisplayedElements.Sort();
            foreach (var value in DisplayedElements)
                Console.WriteLine(value.ToString());

        }
    }
}
