Feature: LoginScenarios
	Sign in with no credentials
	Sign in with email and empty password
	Sign in with password and empty email
	Sign in with incorrect credentials

@mytag
Scenario:TC_01_LoginWithoutCredentials
	Given I have navigated to login page
	When I press SignIn
	Then Error message for credentials should be displayed

Scenario:TC_02_LoginWithoutPassword
	Given I have navigated to login page
	And  I have entred email
	When I press SignIn
	Then Error message for password should be displayed

Scenario:TC_03_LoginWithoutEmail
	Given I have navigated to login page
	And  I have entred password
	When I press SignIn
	Then Error message for email should be displayed

Scenario:TC_04_LoginWithInvalidCredentials
	Given I have navigated to login page
	And  I have entred email
	And  I have entred password
	When I press SignIn
	Then Error message for invalid credentitals should be displayed