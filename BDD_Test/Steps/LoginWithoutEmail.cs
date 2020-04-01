using System;
using BDDPageObject;
using System.Data;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BDD_Test.Steps
{
    [Binding]
    public class LoginWithoutEmail
    {
        [Given(@"I have entred password")]
        public void GivenIHaveEntredPassword()
        {
            DataTable dtLogin = CommonMethods.GetDataFromExcelSheet("select * from [Login$]");
            Page.Login.EnterPassword(dtLogin.Rows[0]["Password"].ToString());
        }
        
        [Then(@"Error message for email should be displayed")]
        public void ThenErrorMessageForEmailShouldBeDisplayed()
        {
            Assert.AreEqual(Page.Login.GetError(), "An email address required.");
            Page.Login.CloseApplication();
        }
    }
}
