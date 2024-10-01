using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDATAUITesting.PageObjects
{
    public class CompanyPage
    {
        private IWebDriver driver;

        public CompanyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement CompanySubMenu => driver.FindElement(By.XPath("//nav[@role='navigation']//li[contains(.,'Company')]//a/following::ul//li//a[contains(.,'Overview')]"));
        private IWebElement LetsGetStartedButton => driver.FindElement(By.XPath("//a[contains(text(),\"Let's Get Started\")]"));
        private IWebElement PageHeader => driver.FindElement(By.XPath("//h1[contains(text(),'GET IN TOUCH WITH US')]"));

        public void ClickCompanySubMenu()
        {
            CompanySubMenu.Click();
        }

        public void ClickLetsGetStartedButton()
        {
            LetsGetStartedButton.Click();
        }

        public bool IsPageHeaderDisplayed()
        {
            try
            {
                return PageHeader.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
