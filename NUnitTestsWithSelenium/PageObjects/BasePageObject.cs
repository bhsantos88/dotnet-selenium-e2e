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

        public string GetDropdownSelectedOption(IWebElement element)
        {
            SelectElement selectElement = new SelectElement(element);
            return selectElement.SelectedOption.Text;
        }
        public IList<IWebElement> GetDropdownAllSelectedOptions(IWebElement element)
        {
            SelectElement selectElement = new SelectElement(element);
            return selectElement.AllSelectedOptions;
        }
        public string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public void NavigateTo()
        {
            webDriver.Navigate().GoToUrl(defaultUrl);
        }
        public void SetText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        public void SetDropdownSelection(IWebElement element, string value, DropdrownSelection dropdrownSelection)
        {
            SelectElement selectElement = new SelectElement(element);

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
        public void Submit(IWebElement element)
        {
            element.Submit();
        }
    }
}
