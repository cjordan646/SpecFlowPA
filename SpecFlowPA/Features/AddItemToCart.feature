Feature: AddItemToCart

As a user I want to be able to add an item to my shopping and purchase the item

@tag1
Scenario: Add item to Cart
	Given I am on the Home page
	And I  mouse hover over an item
	When I click on the add to cart button for an item
	Then The item is successfully added to the shopping cart
