using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTestsWithSelenium.PageObjects
{
    public enum ElementType
    {
        ClassName,
        CssSelector,
        Id,
        Name
    }

    public enum DropdrownSelection
    {
        ByText,
        ByValue,
        ByIndex
    }
    public abstract class BasePageObject<T>
    {
        private readonly IWebDriver webDriver;

        public BasePageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver ?? throw new ArgumentNullException();
        }

        public void Click(string element, ElementType type)
        {
            IWebElement webElement = GetElement(element, type);
            webElement.Click();
        }
        public void EnterValue(string element, string value, ElementType type)
        {
            IWebElement webElement = GetElement(element, type);
            webElement.SendKeys(value);
        }
        public IWebElement GetElement(string element, ElementType type)
        {
            IWebElement webElement = null;

            switch (type)
            {
                case ElementType.ClassName:
                    webElement = webDriver.FindElement(By.ClassName(element));
                    break;
                case ElementType.CssSelector:
                    webElement = webDriver.FindElement(By.CssSelector(element));
                    break;
                case ElementType.Id:
                    webElement = webDriver.FindElement(By.Id(element));
                    break;
                case ElementType.Name:
                    webElement = webDriver.FindElement(By.Name(element));
                    break;
                default:
                    break;
            }

            return webElement;
        }
        public void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
        public string ReadValue(string element, ElementType type)
        {
            IWebElement webElement = GetElement(element, type);
            return webElement.Text;
        }
        public void SelectDropDown(string element, string value, ElementType type, DropdrownSelection dropdrownSelection)
        {
            IWebElement webElement = GetElement(element, type);
            SelectElement selectElement = new SelectElement(webElement);

            switch (dropdrownSelection)
            {
                case DropdrownSelection.ByText:
                    selectElement.SelectByText(value);
                    break;
                case DropdrownSelection.ByValue:
                    selectElement.SelectByValue(value);
                    break;
                case DropdrownSelection.ByIndex:
                    int integerValue = 0;
                    int.TryParse(value, out integerValue);
                    selectElement.SelectByIndex(integerValue);
                    break;
                default:
                    break;
            }
        }
    }
}
