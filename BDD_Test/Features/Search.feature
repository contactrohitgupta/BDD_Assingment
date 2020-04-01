Feature: Search
	Search for a Multi-City flight with 3 flights 
	(A to B, B to C and C to A). 
	The whole trip should be 1 week long for 4 adults. 

@mytag
Scenario: TC_05_SearchFlights
	Given I have navigated to application
	And I have pressed flights
	And I have pressed Multicity
	And I have entred first origin city
	And I have entred first destination city
	And I have entred departing date
	And I have entred person count
	And I have entred second origin city
	And I have entred second destination city
	And I have entred second departing date
	And I have clicked add another city
	And I have entred third origin city
	And I have entred third destination city
	And I have entred third departing date
	And I have clicked on search
	And I have clicked first select
	And I have clicked second select
	And I have clicked third select
	Then the total amount must be one person amount multiply by four
