

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Data;
using BDDCore;
using System.Configuration;

namespace BDDPageObject
{
    /// <summary>
    /// This class is repesenting the login page. 
    /// It has all the page element of login page and have method need for login.
    /// </summary>
    public class LoginPage
    {
        public string ErrorMessage {get;set;}


        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        [CacheLookup]
        public IWebElement Password { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'alert alert-danger')]/ol/li")]
        [CacheLookup]
        public IWebElement LoginError { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        [CacheLookup]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='lbtnLogout']")]
        [CacheLookup]
        public IWebElement LogOut { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div/a[contains(@class, 'login')]")]
        [CacheLookup]
        public IWebElement SignIn { get; set; }
        public void LoadApplication()
        {
            try
            {
                
                BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["AppUrl"].ToString());
                SignIn.Click();
                Element_Extensions.AddExpleciteWait(100);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void EnterEmailAddress(string strEmail)
        {
            EmailAddress.EnterText(strEmail, "Email");
        }
        public void EnterPassword(string strPassword)
        {
            Password.EnterText(strPassword, "Password");
        }
        public void ClickLoginButton()
        {
            Login.ClickOnIt("Login Button");
        }
        public string GetError()
        {
            if (LoginError.IsDisplayed("Login Error"))
                return ErrorMessage = LoginError.Text.ToString();
            else
                return string.Empty;

        }
        /// <summary>
        /// This method is used to login into the application.
        /// </summary>
        /// <param name="strUserName">Username to enter</param>
        /// <param name="strPassword">Password to enter</param>
        /// <returns>True if successful login. False if login failed.</returns>
        public bool LoginToApplication(string strUserName,string strPassword)
        {
            try
            {
               

                ErrorMessage = string.Empty;

                //EmailAddress.EnterText(strUserName, "Email");
                
                //Password.EnterText(strPassword, "Password");
                

                //Login.ClickOnIt("Login Button");
                

                if (LoginError.IsDisplayed("Login Error"))
                {
                    ErrorMessage = LoginError.Text.ToString();

                    return false;

                }
               
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public bool LogOutToApplication()
        {
            try
            {
                LogOut.Click();
                
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        
    }
}
