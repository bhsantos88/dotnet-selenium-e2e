using OpenQA.Selenium;

namespace NUnitTestsWithSelenium.PageObjects
{
    public class UserFormPage : BasePageObject<UserFormPage>
    {
        public UserFormPage(IWebDriver webDriver) 
            : base (webDriver)
        {
        }
    }
}
