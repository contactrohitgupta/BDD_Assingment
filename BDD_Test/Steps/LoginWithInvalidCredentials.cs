using BDDPageObject;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BDD_Test.Steps
{
    [Binding]
    public class LoginWithInvalidCredentials
    {
        [Then(@"Error message for invalid credentitals should be displayed")]
        public void ThenErrorMessageForInvalidCredentitalsShouldBeDisplayed()
        {
            Assert.AreEqual(Page.Login.GetError(), "Authentication failed.");
            Page.Login.CloseApplication();
        }
    }
}
