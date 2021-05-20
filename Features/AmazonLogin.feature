@login
Feature: Login
	Check whether login text is visible without providing any email account

Scenario Outline: Check login text without any email
Given An user navigate to browser '<url>'
And hoverover the SignInOption 
And click on the SignIn button
When Clicked on the Continue without any data
Then error message should show '<Expected result>'
Examples: 
|url                   |Expected result                        |
|https://www.amazon.com|Enter your email or mobile phone number|