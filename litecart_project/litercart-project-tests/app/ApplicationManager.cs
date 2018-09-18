using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LitecartTests
{
    public class ApplicationManager
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
     
        private MainPage MainPage { get; set; }
        private ProductPage ProductPage { get; set; }
        private CartPage CartPage { get; set; }

        protected string BaseURL => "http://localhost";

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            options.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
            Driver = new ChromeDriver(options);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Cookies.DeleteAllCookies();

            MainPage = new MainPage(Driver);
            ProductPage = new ProductPage(Driver);
            CartPage = new CartPage(Driver);            
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Driver.Url = "http://localhost/litecart/en/";
                app.Value = newInstance;
            }
            return app.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
                Driver = null;
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public void RemoveFromCart()
        {
            MainPage.OpenCart(); 
            CartPage.Remove(0);
            CartPage.GoBackToMainStorePage();
        }

        public void AddProductToCart()
        {
            MainPage.OpenProductCard();
            ProductPage.InitProductAddingToСart();
            MainPage.GetProductQuantity();
            MainPage.GoToMainPage();
        }
    }
}