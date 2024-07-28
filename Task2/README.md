# Postman API Testing Collection

This project involves creating a Postman collection to interact with the API from the provided Postman workspace link. The tasks include creating a new booking, verifying the response values, and ensuring the new booking ID is present in the list of booking IDs.

## Technologies Used
- Postman
- JavaScript (for test scripts)

## Task Overview

### 1. Create a New Booking
- **Endpoint**: `POST /booking`
- **Request Body**: Include details such as firstname, lastname, total price, deposit paid, booking dates, and additional needs.

### 2. Verify Values in the Response
- **Test Script**: Verify that the values returned in the response match the values sent in the request. Set the booking ID in the environment.

### 3. Verify Booking ID in GetBookingIds Response
- **Endpoint**: `GET /booking`
- **Test Script**: Verify that the new booking ID is present in the response of GetBookingIds.

## Steps to Complete the Tasks

### Fork the Postman Collection
1. Open the provided link in Postman.
2. Click the “Fork” button to create a personal copy of the workspace.

### Create a New Collection
1. Name the collection "Booking API Tests".

### Add Requests and Test Scripts
1. Add a request to create a new booking with the specified payload.
2. Add a test script to verify the values in the response.
3. Add another request to get booking IDs and verify the presence of the new booking ID.

## Setup Instructions
1. Clone the repository.
2. Open the Postman app.
3. Import the Postman collection and environment.
4. Run the collection using the Collection Runner in Postman.
