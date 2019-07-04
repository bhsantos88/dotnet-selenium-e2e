using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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
        public readonly IWebDriver webDriver;
        public readonly string defaultUrl;

        public BasePageObject(IWebDriver webDriver, string defaultUrl)
        {
            this.webDriver = webDriver ?? throw new ArgumentNullException();
            this.defaultUrl = defaultUrl ?? throw new ArgumentNullException();
        }

        public string GetDropdownSelectedOption(IWebElement webElement)
        {
            SelectElement selectElement = new SelectElement(webElement);
            return selectElement.SelectedOption.Text;
        }
        public IList<IWebElement> GetDropdownAllSelectedOptions(IWebElement webElement)
        {
            SelectElement selectElement = new SelectElement(webElement);
            return selectElement.AllSelectedOptions;
        }
        public string GetText(IWebElement webElement)
        {
            return webElement.GetAttribute("value");
        }
        public void NavigateTo()
        {
            webDriver.Navigate().GoToUrl(defaultUrl);
        }
        public void SetDropdownSelection(IWebElement webElement, string value, DropdrownSelection dropdrownSelection)
        {
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
        public void SetText(IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
        }
        public void Submit(IWebElement webElement)
        {
            webElement.Submit();
        }
    }
}
