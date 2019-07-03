using NUnit.Framework;
using NUnitTestsWithSelenium;
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
        [TestCase("TitleId", "Mr.", ExpectedResult = "Mr.")]
        [TestCase("TitleId", "Ms.", ExpectedResult = "Ms.")]
        public string TestDropDownSelection(string id, string value)
        {
            UserFormPage userForm = new UserFormPage(driver);
            userForm.NavigateTo("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
            userForm.SelectDropDown(id, value, ElementType.Id, DropdrownSelection.ByText);

            string res = userForm.ReadValue(id, ElementType.Id);

            return res;
        }

        [Test]
        public void TestFillFields()
        {
            UserFormPage userForm = new UserFormPage(driver);
            userForm.NavigateTo("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
            
            userForm.SelectDropDown("TitleId", "Mr.", ElementType.Id, DropdrownSelection.ByText);
            userForm.EnterValue("Initial", "New name", ElementType.Name);
            userForm.Click("Save", ElementType.Name);
        }
    }
}