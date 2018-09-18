using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace LitecartTests
{
    internal class ProductPage : Page
    {   
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        public IWebElement addToCartButton;

        [FindsBy(How = How.CssSelector, Using = "select[name^=options]")]
        public IWebElement Size;

        public ProductPage InitProductAddingToСart()
        {
            if (IsElementPresent(By.CssSelector("select[name^=options]")))
            {
                new SelectElement(Size).SelectByIndex(1);
            }
            addToCartButton.Click();
            return this;
        }       
    }
}