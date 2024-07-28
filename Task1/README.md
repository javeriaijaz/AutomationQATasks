# AutomationQATasks_NextBasket

# Test Store Automation

## Overview

This project involves automating various test scenarios on the test store available at [Test Store](https://teststoreforsouthafri.nextbasket.shop/). The tasks include automating tests for ordering a product, verifying labels, creating BDD test cases for checkout, and identifying bugs.

## Prerequisites

- Visual Studio Code
- .NET Core SDK
- NUnit
- Selenium WebDriver
- ChromeDriver

## Project Structure

- `OrderProductSteps.cs`: Contains the steps for ordering the first in-stock non-promo product.
- `VerifyDiscountLabelSteps.cs`: Contains the steps for verifying that the "50% off" label is visible.
- `TestCases.txt`: Contains 10 BDD test cases for the checkout process.
- `Bugs.txt`: Contains descriptions of at least two bugs found on the website.

## Instructions

### 1. Order the First In-Stock Non-Promo Product

This test navigates to the test store, selects the first in-stock non-promo product, and proceeds through the checkout process using South Africa as the country and Alberton as the city.

### 2. Verify "50% off" Label Visibility

This test verifies that the "50% off" label is visible on the product page.

### 3. BDD Test Cases for Checkout

The file `TestCases.txt` contains 10 BDD test cases for the checkout process.

### 4. Describe at Least Two Bugs

The file `Bugs.txt` contains descriptions of at least two bugs identified during the testing process.

---

## File Descriptions

### `OrderProductSteps.cs`

This file contains the steps to automate the ordering of the first in-stock non-promo product. It includes:

- Navigating to the test store.
- Handling the cookies consent.
- Selecting the first non-promo product.
- Proceeding through the checkout process.
- Filling in the necessary details and placing the order.

### `VerifyDiscountLabelSteps.cs`

This file contains the steps to verify that the "50% off" label is visible on the product page. It includes:

- Navigating to the test store.
- Handling the cookies consent.
- Verifying the visibility of the "50% off" label.

### `TestCases.txt`

This file contains 10 BDD test cases for the checkout process. The test cases cover various scenarios such as:

- Validating the checkout flow with different payment methods.
- Verifying error messages for invalid inputs.
- Ensuring successful order placement with valid data.
- Testing the user experience across different browsers and devices.

### `Bugs.txt`

This file describes at least two bugs identified during the testing process. Each bug includes:

- A brief description of the bug.
- Steps to reproduce the bug.
- The expected and actual results.
- Screenshots or logs if applicable.

