Feature: Order the first in-stock non-promo product
  Scenario: Order the first in-stock non-promo product
    Given I am on the test store
    When I order the first in-stock non-promo product using South Africa as Country and Alberton as City
    Then the order should be placed successfully