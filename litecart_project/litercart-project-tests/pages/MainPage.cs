using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LitecartTests
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public string BaseURL => "http://localhost";       

        [FindsBy(How = How.XPath, Using = ".//div[@id='logotype-wrapper']/a[@href]")]
        public IWebElement Logo;

        [FindsBy(How = How.CssSelector, Using = ".product")]
        public IWebElement FirstItem;

        [FindsBy(How = How.CssSelector, Using = "#cart .link[href*=checkout]")]
        public IWebElement OpenCartBtn;

        [FindsBy(How = How.CssSelector, Using = "#cart span.quantity")]
        public IWebElement CartQty;                

        public MainPage OpenProductCard()
        {
            FirstItem.Click();
            return this;
        }

        public MainPage GoToMainPage()
        {
            Logo.Click();
            return this;
        }
        public MainPage OpenCart()
        {
            OpenCartBtn.Click();
            return this;
        }

        public MainPage GetProductQuantity()
        {           
            string expQty = (int.Parse(CartQty.GetAttribute("textContent")) + 1).ToString();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1.5));
            Wait.Until(driver => CartQty.GetAttribute("textContent").Equals(expQty));
            return this;
        }

        public MainPage OpenMainPage()
        {
            if (Driver.Url == $"{BaseURL}/litecart/en/")
            {
                return this;
            }
            Driver.Navigate().GoToUrl($"{BaseURL}/litecart/");
            return this;
        }
    }
}