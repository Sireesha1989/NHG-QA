Feature: Location test

Scenario Outline: Make successful location information
Given I make a request to get location information <countryCode>,<postCode>
Then I verify the request status <isSuccessful>
Examples: 
| countryCode | postCode | isSuccessful |
| AD          | AD100    | True         |
| AT          | 96799    | False        |