using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AGDATAUITesting.PageObjects;

namespace AGDATAUITesting
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private HomePage homePage;
        private CompanyPage companyPage;

        [TestInitialize]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);
            companyPage = new CompanyPage(driver);
        }

        [TestMethod]
        public void TestCompanyNavigation()
        {
            driver.Navigate().GoToUrl("https://www.agdata.com/");
            homePage.ClickCompanyMenu();
            companyPage.ClickCompanySubMenu();
            companyPage.ClickLetsGetStartedButton();

            Assert.IsTrue(companyPage.IsPageHeaderDisplayed(), "'GET IN TOUCH WITH US' header is not displayed.");
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}