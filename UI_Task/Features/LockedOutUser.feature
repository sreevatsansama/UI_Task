Feature: Locked out user is prohibited from logging in

Scenario: Locked out user attempts to log in
  Given I am a locked out user on the Sauce Labs login page
  When I log in as a locked out user
  Then I should see an error message indicating I am locked out