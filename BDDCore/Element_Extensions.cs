using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BDDCore

{
    public static class Element_Extensions
    {
        public static void WaitForLoad(this IWebDriver driver, int timeoutSec = 15)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static void EnterText(this IWebElement element, string text, string elementName)
        {

            element.Clear();
            element.SendKeys(text);
            Console.WriteLine(text + " entered in the " + elementName + " field.");
        }

        public static bool IsDisplayed(this IWebElement element, string elementName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine(elementName + " is Displayed.");
            }
            catch (Exception)
            {
                result = false;
                Console.WriteLine(elementName + " is not Displayed.");
            }

            return result;
        }

        public static void ClickOnIt(this IWebElement element, string elementName)
        {
            if (element.Displayed)
            {
                element.Click();
                ///Console.WriteLine("Clicked on " + elementName);
            }
        }

        public static void SelectByText(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
            Console.WriteLine(text + " text selected on " + elementName);
        }

        public static void SelectByIndex(this IWebElement element, int index, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByIndex(index);
            Console.WriteLine(index + " index selected on " + elementName);
        }

        public static void SelectByValue(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(text);
            Console.WriteLine(text + " value selected on " + elementName);
        }

        public static void AddImpleciteWait(int seconds)
        {
            BrowserFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        public static IWebElement FindElementById(string idToFind)
        {
            return BrowserFactory.Driver.FindElement(By.Id(idToFind));
        }

        public static void AddExpleciteWait(int miliSeconds)
        {
            System.Threading.Thread.Sleep(miliSeconds);
        }

        public static void ScrollWindow()
        {
            IJavaScriptExecutor js = BrowserFactory.Driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,250)");
        }

        public static void InputUsingJS(this IWebElement element, string inputValue)
        {
            IJavaScriptExecutor js = BrowserFactory.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].setAttribute('value', '" + inputValue + "')", element);
        }

        public static void InputByJS(this IWebElement element, string inputValue)
        {
            IJavaScriptExecutor js = BrowserFactory.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].value='"+ inputValue+"'", element);
        }

        public static void ClickUsingJs(this IWebElement element)
        {
            IJavaScriptExecutor js = BrowserFactory.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", element);
        }

       

    }
}
