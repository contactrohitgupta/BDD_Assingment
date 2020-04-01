using System;
using BDDPageObject;
using System.Data;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BDD_Test.Steps
{
    [Binding]
    public class LoginWithoutPassword
    {
        [Given(@"I have entred email")]
        public void GivenIHaveEntredEmail()
        {
            DataTable dtLogin = CommonMethods.GetDataFromExcelSheet("select * from [Login$]");
            Page.Login.EnterEmailAddress(dtLogin.Rows[0]["Email"].ToString());
        }

        [Then(@"Error message for password should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            Assert.AreEqual(Page.Login.GetError(), "Password is required.");
            Page.Login.CloseApplication();
        }
    }
}
