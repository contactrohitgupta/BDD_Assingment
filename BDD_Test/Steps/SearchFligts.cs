using System;
using BDDPageObject;
using System.Data;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BDD_Test
{
    [Binding]
    public class SearchFligts
    {
        [Given(@"I have navigated to application")]
        public void GivenIHaveNavigatedToApplication()
        {
            //DataTable dtLogin = CommonMethods.GetDataFromExcelSheet("select * from [Login$]");
            Page.Search.LoadApplication();
        }
        
        [Given(@"I have pressed flights")]
        public void GivenIHavePressedFlights()
        {
            Page.Search.ClickButton(Page.Search.ButtonFlight);
        }
        
        [Given(@"I have pressed Multicity")]
        public void GivenIHavePressedMulticity()
        {
            Page.Search.ClickButton(Page.Search.ButtonMultiFlight);
        }
        
        [Given(@"I have entred first origin city")]
        public void GivenIHaveEntredFirstOriginCity()
        {
            Page.Search.EnterTextBoxValue(Page.Search.InputFligtOrigin,"Luqa");
        }
        
        [Given(@"I have entred first destination city")]
        public void GivenIHaveEntredFirstDestinationCity()
        {
            Page.Search.EnterTextBoxValue(Page.Search.InputFligtDestination, "LON");
        }
        
        [Given(@"I have entred departing date")]
        public void GivenIHaveEntredDepartingDate()
        {
            Page.Search.ClickButton(Page.Search.DepartureDateFirst);
            Page.Search.ClickButton(Page.Search.InputFligtDeparting);
        }
        
        [Given(@"I have entred person count")]
        public void GivenIHaveEntredPersonCount()
        {
            Page.Search.ClickButton(Page.Search.InputTraveller);
            for(int i=1;i<4;i++)
            {
                Page.Search.ClickButton(Page.Search.AddTraveller);
            }
        }
        
        [Given(@"I have entred second origin city")]
        public void GivenIHaveEntredSecondOriginCity()
        {
            Page.Search.EnterTextBoxValue(Page.Search.InputFligtTwoOrigin, "LON");
        }
        
        [Given(@"I have entred second destination city")]
        public void GivenIHaveEntredSecondDestinationCity()
        {
            Page.Search.EnterTextBoxValue(Page.Search.InputFligtTwoDestination, "ROM");
        }
        
        [Given(@"I have entred second departing date")]
        public void GivenIHaveEntredSecondDepartingDate()
        {
            Page.Search.ClickButton(Page.Search.DepartureDateTwo);
            Page.Search.ClickButton(Page.Search.InputFligtTwoDeparting);
        }

        [Given(@"I have clicked add another city")]
        public void GivenIHaveAddAnotherCity()
        {
            Page.Search.ClickButton(Page.Search.AddAnotherCity);
        }

        [Given(@"I have entred third origin city")]
        public void GivenIHaveEntredThirdOriginCity()
        {
            Page.Search.EnterTextBoxValue(Page.Search.InputFligtThreeOrigin, "ROM");
        }
        
        [Given(@"I have entred third destination city")]
        public void GivenIHaveEntredThirdDestinationCity()
        {
            Page.Search.EnterTextBoxValue(Page.Search.InputFligtThreeDestination, "LON");
        }
        
        [Given(@"I have entred third departing date")]
        public void GivenIHaveEntredThirdDepartingDate()
        {
            Page.Search.ClickButton(Page.Search.DepartureDateThree);
            Page.Search.ClickButton(Page.Search.InputFligtThreeDeparting);
        }
        
        [Given(@"I have clicked on search")]
        public void GivenIHaveClickedOnSearch()
        {
            Page.Search.ClickButton(Page.Search.ButtonSearch,15000);
            
        }
        
        [Given(@"I have clicked first select")]
        public void GivenIHaveClickedFirstSelect()
        {
            Page.Search.ClickButton(Page.Search.ButtonFirstSelect,15000);
        }
        
        [Given(@"I have clicked second select")]
        public void GivenIHaveClickedSecondSelect()
        {
            Page.Search.ClickButton(Page.Search.ButtonFirstSelect,15000);
        }
        
        [Given(@"I have clicked third select")]
        public void GivenIHaveClickedThirdSelect()
        {
            Page.Search.ClickButton(Page.Search.ButtonFirstSelect,15000);
            Page.Search.SwitchToWindow("Trip Detail | Expedia");
        }
        
        [Then(@"the total amount must be one person amount multiply by four")]
        public void ThenTheTotalAmountMustBeOnePersonAmountMultiplyByfour()
        {
            string str = Page.Search.TotalPrice.Text;
            double onePersonExpense = Convert.ToDouble(Page.Search.OnePersonPrice.Text.Remove(0,1));
            double fourPersonExpense = Convert.ToDouble(Page.Search.TotalPrice.Text.Remove(0,1));

            Assert.AreEqual(fourPersonExpense, onePersonExpense * 4);
        }
    }
}
