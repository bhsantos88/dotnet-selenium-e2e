using NUnitTestsWithSelenium.TableHelpers;
using OpenQA.Selenium;

namespace NUnitTestsWithSelenium.PageObjects
{
    public class TablePageObject : BasePageObject<TablePageObject>
    {
        public IWebElement table => webDriver.FindElement(By.ClassName("table"));   

        public TablePageObject(IWebDriver webDriver, string defaultUrl)
            : base(webDriver, defaultUrl)
        {
        }
    }
}
