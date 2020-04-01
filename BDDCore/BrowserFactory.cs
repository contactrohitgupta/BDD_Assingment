using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BDDCore
{
    public class BrowserFactory
    {
        public enum Browser
        {
            Chrome,
            IE,
            Firefox,
            Opera
        }
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(Browser browserName)
        {
            try
            {
                switch (browserName)
                {
                    case Browser.Firefox:
                        if (Driver == null)
                        {
                            driver = new FirefoxDriver();
                            Drivers.Add("Firefox", Driver);
                        }
                        break;

                    case Browser.IE:
                        if (Driver == null)
                        {
                            driver = new InternetExplorerDriver();
                            Drivers.Add("IE", Driver);
                        }
                        break;

                    case Browser.Chrome:
                        if (Driver == null)
                        {
                            driver = new ChromeDriver();
                            Drivers.Add("Chrome", Driver);
                        }
                        break;
                }
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception ex)
            {
                throw(ex);;
            }
}

        public static void LoadApplication(string url)
        {
            try
            {
                Driver.Url = url;
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Driver.Manage().Cookies.DeleteAllCookies();
            }
            catch(Exception ex)
            {
                throw(ex);;
            }
        }
        public static Boolean SwitchWindow(string title)
        {
            var currentWindow = driver.CurrentWindowHandle;
            var availableWindows = new List<string>(driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    driver.SwitchTo().Window(w);
                    if (driver.Title == title)
                        return true;
                    else
                    {
                        driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            return false;
        }
        public static void CloseAllDrivers()
        {
            try
            {
                foreach (var key in Drivers.Keys)
                {
                    Drivers[key].Close();
                    Drivers[key].Quit();
                }
            }
            catch (Exception ex)
            {
                throw(ex);;
            }
        }
    }
}
