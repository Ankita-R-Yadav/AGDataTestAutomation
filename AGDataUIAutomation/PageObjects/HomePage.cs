using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDATAUITesting.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement CompanyMenu => driver.FindElement(By.XPath("//nav[@role='navigation']//li[contains(.,'Company')]//a"));

        public void ClickCompanyMenu()
        {
            CompanyMenu.Click();
        }

    }
}
