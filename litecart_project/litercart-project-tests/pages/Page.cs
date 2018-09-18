using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LitecartTests
{
    public class Page
    {
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }       

        public Page(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }   

        public bool IsElementPresent(By locator)
        {
            try
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                return Driver.FindElements(locator).Count > 0;
            }
            finally
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }        
        }
    }
}