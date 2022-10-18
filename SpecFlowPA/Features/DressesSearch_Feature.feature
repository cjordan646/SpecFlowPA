Feature: DressesSearch_Feature

As a user i want to be able to search for Dresses

@SearchBar
Scenario: Search for Dresses
	Given the user is on the home page
	When I have entered Dresses in the search field
	And I click the search button
	Then the results page for Dresses is displayed

