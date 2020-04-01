using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using BDDCore;
using System.Configuration;

namespace BDDPageObject
{
    public class SearchFlights
    {
        [FindsBy(How = How.XPath, Using = "//button[@id='tab-flight-tab-hp']")]
        [CacheLookup]
        public IWebElement ButtonFlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='flight-type-multi-dest-label-hp-flight']")]
        [CacheLookup]
        public IWebElement ButtonMultiFlight { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='flight-origin-hp-flight']")]
        [CacheLookup]
        public IWebElement InputFligtOrigin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='flight-destination-hp-flight']")]
        [CacheLookup]
        public IWebElement InputFligtDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='datepicker-cal-weeks']//td[contains(@class,'datepicker-day-number')]/button[@data-month='4' and @data-day='11']")]
        [CacheLookup]
        public IWebElement InputFligtDeparting { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='flight-2-origin-hp-flight']")]
        [CacheLookup]
        public IWebElement InputFligtTwoOrigin { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='flight-2-destination-hp-flight']")]
        [CacheLookup]
        public IWebElement InputFligtTwoDestination { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[@class='datepicker-cal-weeks']//td[contains(@class,'datepicker-day-number')]/button[@data-month='4' and @data-day='14']")]
        [CacheLookup]
        public IWebElement InputFligtTwoDeparting { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='flight-3-origin-hp-flight']")]
        [CacheLookup]
        public IWebElement InputFligtThreeOrigin { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='flight-3-destination-hp-flight']")]
        [CacheLookup]
        public IWebElement InputFligtThreeDestination { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[@class='datepicker-cal-weeks']//td[contains(@class,'datepicker-day-number')]/button[@data-month='4' and @data-day='17']")]
        [CacheLookup]
        public IWebElement InputFligtThreeDeparting { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/meso-native-marquee/section/div/div/div[1]/section/div/div[2]/div[2]/section[1]/form/div[8]/label/button")]
        [CacheLookup]
        public IWebElement ButtonSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[12]/section/div/div[10]/ul/li[1]/div[1]/div[1]/div[2]/div/div[2]/button")]
        [CacheLookup]
        public IWebElement ButtonFirstSelect { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div[2]/section[1]/div/div[2]/div/div[1]/span[2]")]
        [CacheLookup]
        public IWebElement TotalPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='totalPriceForPassenger1-desktopView']")]
        [CacheLookup]
        public IWebElement OnePersonPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='traveler-selector-hp-flight']//button[@data-gcw-component='gcw-traveler-amount-select']")]
        [CacheLookup]
        public IWebElement InputTraveller { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[text()='Add Adult']//preceding-sibling::span[@class='uitk-icon']/..)[1]")]
        [CacheLookup]
        public IWebElement AddTraveller { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='add-flight-leg-hp-flight']")]
        [CacheLookup]
        public IWebElement AddAnotherCity { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//input[@id='flight-departing-single-hp-flight']")]
        [CacheLookup]
        public IWebElement DepartureDateFirst { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='flight-2-departing-hp-flight']")]
        [CacheLookup]
        public IWebElement DepartureDateTwo { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='flight-3-departing-hp-flight']")]
        [CacheLookup]
        public IWebElement DepartureDateThree { get; set; }
        public void LoadApplication()
        {
            try
            {
                BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["SearchAppUrl"].ToString());
                Element_Extensions.AddExpleciteWait(100);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClickButton(IWebElement element)
        {
            element.Click();
            Element_Extensions.AddExpleciteWait(10);
        }
        public void ClickButton(IWebElement element,int delay)
        {
            element.Click();
            Element_Extensions.AddExpleciteWait(delay);
        }
        public void SwitchToWindow(string strTitle)
        {
            BrowserFactory.SwitchWindow(strTitle);
        }
        public void EnterTextBoxValue(IWebElement element, string strValue)
        {
            element.EnterText(strValue, "");
            element.SendKeys(Keys.Tab);
        }
        
        
    }
}
