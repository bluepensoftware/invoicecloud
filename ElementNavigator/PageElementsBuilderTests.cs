using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementNavigator
{
    [TestFixture]
    public class PageElementsBuilderTests
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("..\\..\\chrome");
            driver.Url = "https://the-internet.herokuapp.com/add_remove_elements/";
            AddElements(5);
        }

        private void AddElements(int number)
        {
            IWebElement addElementButton = driver.FindElement(By.XPath("//*[text()='Add Element']"));
            if (addElementButton != null){

                for (int i = 0; i < number; i++){
                    addElementButton.Click();
                }
            }
        }

        [TestCase(5)]
        public void Exist_N_NumberOfElements(int number)
        {
            IList<IWebElement> listOfElements = driver.FindElements(By.CssSelector("button[class ='added-manually']")).ToList();
            Assert.IsTrue(listOfElements.Count() == number, string.Format("{0} number of elements exist on the page", number));
        }

        [TearDown]
        public void CloseBrowser()
        {            
            driver.Close();
        }
    }
}
