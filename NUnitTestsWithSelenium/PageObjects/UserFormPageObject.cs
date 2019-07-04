using OpenQA.Selenium;

namespace NUnitTestsWithSelenium.PageObjects
{
    public class UserFormPageObject : BasePageObject<UserFormPageObject>
    {
        public IWebElement ddlTitleId => webDriver.FindElement(By.Name("TitleId"));
        public IWebElement txtInitial => webDriver.FindElement(By.Name("Initial"));
        public IWebElement txtFirstName => webDriver.FindElement(By.Name("FirstName"));
        public IWebElement txtMiddleName => webDriver.FindElement(By.Name("MiddleName"));
        public IWebElement btnSave => webDriver.FindElement(By.Name("Save"));
        
        public UserFormPageObject(IWebDriver webDriver, string defaultUrl) 
            : base (webDriver, defaultUrl)
        {
        }

        public void FillUserForm(string titleId, string initial, string firstName, string middleName)
        {
            SetDropdownSelection(ddlTitleId, titleId, DropdrownSelection.ByText);
            SetText(txtInitial, initial);
            SetText(txtFirstName, firstName);
            SetText(txtFirstName, firstName);
            SetText(txtMiddleName, middleName);
        }
    }
}
