Feature: LoginWithoutCredentials
	Sign in with no credentials

@mytag
Scenario:TC_01_LoginWithoutCredentials
	Given I have navigated to login page
	When I press SignIn
	Then Error message should be displayed
