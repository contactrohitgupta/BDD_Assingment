using System;
using BDDPageObject;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD_Test
{
    [Binding]
    public class LoginWithoutCredentialsSteps
    {
        [Given(@"I have navigated to login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            
            Page.Login.LoadApplication();
        }

        [When(@"I press SignIn")]
        public void WhenIPressSignIn()
        {
            Page.Login.ClickLoginButton();
        }

        [Then(@"Error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            Assert.AreEqual(Page.Login.GetError(), "An email address required.");
        }
    }
}
