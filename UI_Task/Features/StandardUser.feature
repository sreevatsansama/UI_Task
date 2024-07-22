Feature: Standard user can place an order

Scenario: Standard user successfully logs in and places an order
  Given I am a standard user on the Sauce Labs login page
  When I log in as a standard user
  And I add an item to the cart
  And I proceed to checkout
  And I enter my shipping information
  And I complete the purchase
  Then I should see a confirmation message that my order was placed
