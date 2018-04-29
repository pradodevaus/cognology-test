# cognology-test
## Acme Remote Flights APIs

### Technology Stack:
1. ASP.NET Web API 2 (wanted to use Asp.Net core 2.0 but could not install VS2017)
2. Used Entity Framework 6 for data access
3. Used Moq for mocking in unit test
4. Used Repository pattern with Unit of Work in data layer
5. Used service layer to encapsulate business logic

### Implemented below APIs (Please refer Postman collection in "PostmanCollection" folder in "Arf.WebApi" project for sample API request/response)
1. List all flights
2. Search for bookings (by Lastname, TravelDate, FlightNumber)
3. Check availability (by TravelDate, No. of pax, DepatureCity, ArrivalCity)
4. Make booking (by TravelDate, FlightNumber, Passenger details)

### Pending work
1. Unit tests for booking api and service
2. Integration tests for data layer
3. Authentication and Authorization(OAuth 2.0) in api project
4. Implement OpenAPI for documentation

### Steps to run the project
1. Clone this repository
2. Open the solution in VS2015 or higher
3. To setup database, run "Update-Database" in Package Manager Console, please select "Arf.Data" project
4. All api endpoints has format: http://localhost:8080/api/v1/{}
