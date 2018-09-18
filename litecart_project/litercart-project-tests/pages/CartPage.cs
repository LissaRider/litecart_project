using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace LitecartTests
{
    internal class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Name, Using = "remove_cart_item")]
        public IWebElement RemoveButton;

        [FindsBy(How = How.CssSelector, Using = "table.dataTable tr:nth-of-type(2)")]
        public IList<IWebElement> CartProductItemRows;

        [FindsBy(How = How.XPath, Using = ".//a[contains(text(),'Back') and @href]")]
        private IWebElement GoBackBtn;

        public void GoBackToMainStorePage()
        {
            GoBackBtn.Click();
        }

        public void Remove(int index)
        { 
            while (IsElementPresent(By.Name("remove_cart_item")))
            {
                RemoveButton.Click();
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(ExpectedConditions.StalenessOf(CartProductItemRows[index]));
            }
        }
    }
}