Feature: Verify Discount Label Visibility
  In order to ensure promotional labels are displayed correctly
  As a user of the test store
  I want to verify that the "50% off" label is visible on products that are on sale

  Scenario: Verify the "50% off" label visibility on the product page
    Given I am on the test store to verify discount label
    Then the "50% off" label should be visible