using OpenQA.Selenium;

namespace NUnitTestsWithSelenium.PageObjects
{
    public class LoginPageObject : BasePageObject<LoginPageObject>
    {
        public IWebElement txtUserName => webDriver.FindElement(By.Name("UserName"));
        public IWebElement txtPassword => webDriver.FindElement(By.Name("Password"));
        public IWebElement btnLogin => webDriver.FindElement(By.Name("Login"));

        public LoginPageObject(IWebDriver webDriver, string defaultUrl)
            : base(webDriver, defaultUrl)
        {

        }

        public void Login(string user, string password)
        {
            SetText(txtUserName, user);
            SetText(txtPassword, password);
            Submit(btnLogin);
        }
    }
}
