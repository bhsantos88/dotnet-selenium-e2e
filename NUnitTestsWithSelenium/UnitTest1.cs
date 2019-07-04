using NUnit.Framework;
using NUnitTestsWithSelenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Tests
{
    public class Tests
    {
        // Create the reference for the browser.
        IWebDriver driver;
        string loginFormUrl = "http://executeautomation.com/demosite/Login.html";
        string userFormUrl = "http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login";

        // This function will run one time before the first test.
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            string currentPath = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(currentPath);
        }

        // This function will run one time after the last test.
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        // This function will run before each test.
        [SetUp]
        public void Setup()
        {
        }

        // This function will run after each test.
        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        [TestCase("Mr.", ExpectedResult = "Mr.")]
        [TestCase("Ms.", ExpectedResult = "Ms.")]
        public string TestDropDownSelection(string value)
        {
            UserFormPageObject userForm = new UserFormPageObject(driver, userFormUrl);

            userForm.NavigateTo();
            userForm.SetDropdownSelection(userForm.ddlTitleId, value, DropdrownSelection.ByText);

            string res = userForm.GetDropdownSelectedOption(userForm.ddlTitleId);
            return res;
        }

        [Test]
        [TestCase("Mr.", "BH", "Bruno", "Henrique")]
        [TestCase("Mr.", "MM", "Muster", "Müller")]
        public void TestFillUserForm(string titleId, string initial, string firstName, string middleName)
        {
            UserFormPageObject userFormPage = new UserFormPageObject(driver, userFormUrl);
            userFormPage.NavigateTo();

            userFormPage.FillUserForm(titleId, initial, firstName, middleName);
            userFormPage.Submit(userFormPage.btnSave);

            //string fieldValue = userFormPage.GetText(userFormPage.txtInitial);
        }

        [Test]
        public void PerformE2ETests()
        {
            LoginPageObject loginPage = new LoginPageObject(driver, loginFormUrl);
            loginPage.NavigateTo();
            loginPage.Login("test", "123");

            UserFormPageObject userFormPage = new UserFormPageObject(driver, userFormUrl);
            userFormPage.FillUserForm("Mr.", "BH", "Bruno", "Henrique");
        }
    }
}