# OOH Interview Project
This repository contains a simple UI and API for selling inventory in OOH (Out of Home) Advertising.\
The candidate will complete a variety of tasks to improve the system and demonstrate their knowledge.

## Tasks
It's not expected that all tasks are completed.
It's better to do a few tasks well than a lot of tasks rushed.

The tasks cover both UI and API.\
Tasks related to Campaigns are generally more UI focused, and tasks related to Faces are generally more API focused.\
You may choose to do whichever ones you think demonstrate your skillset the best.

It's recommended to create some Unit Tests in the relevant projects. There are existing examples for all Face classes.

## UI Oriented Tasks
### Campaigns Page
* Add a new column that shows the Dates that each Campaign is active during.
  * The existing `/campaigns` endpoint already returns this data.
* Add a new column that shows the total number of Bookings for each Campaign.
  * You can use the `/campaign/id/bookings` endpoint to get the bookings of a campaign.
  * Alternatively, you could add a new endpoint to retrieve all bookings.
* Add a new column that shows the Revenue per Day for each campaign.
  * You can use the `/faces` endpoint to get face information that includes the RatePerDay.
  * You can calculate the total Revenue per Day of a campaign by summing the RatePerDay of each booking
* Add a new column that shows the Total Revenue for each campaign.
  * You can use the `/faces` endpoint to get face information that includes the RatePerDay.
  * You can calculate the Total Revenue of a campaign by summing the total of each booking.
  * The total of each booking is calculated by the number of days in the campaign multiplied by the RatePerDay.
* Add a way for the user to select a Campaign and view all of the related Bookings.
  * You can use the `/campaign/id/bookings` endpoint to get the bookings of a campaign.
  * Optionally, show the RatePerDay of each booking.
  * Optionally, show the Total Revenue of each booking.
  
### Miscellaneous
* Add a Unit Testing framework
* Add an Integration Testing framework
* Refactor parts of the UI to improve maintainability
* Re-implement the UI in React or Angular.
  
## API Oriented Tasks
### Faces
* Add an endpoint to create a Face
* Add an endpoint to calculate the Availability of a Face
  * A Face is Available if there are no Bookings during the provided date range.
  * A Face is Not Available if any bookings overlap with the provided date range.
  * There is an empty endpoint at `/avails` that can be used to guide the implementation
* Move the Dates of a Campaign onto the Booking
  * This would allow the user to run a campaign for a year, and change which faces are booked during that time.
* Add an Address object that can be assigned to a Face.
  * Add an endpoint for retrieving Addresses
    * The endpoint should be `GET /face/id/address`
  * Add an endpoint for creating Addresses 
    * The endpoint should be `POST /face/id/address`

### Bookings
* Add an endpoint to create a Booking
  * Optionally, when creating a Booking, check that the Face is Available first.

### Campaigns
* Add an endpoint to create a Campaign


## Architecture Overview

### API Architecture
The API is built using .NET Core.  It has Unit and Integration Tests.

### UI Archtecture
The UI is built using basic Html, Css and JavaScript. It has Unit Tests.\
It is served as static files from the root URL of the server.

## Developer Setup
1. Install the required dependencies.
1. Use `dotnet run` on the `OohInterview.Api` project, or run from your IDE.

### Dependencies
* .NET Core 3.1

## Application Settings
| Name | Description | Notes |
| ---- | ----------- | ----- |
| UI:ContentDirectory | The Directory of the UI files | These files are served statically |

## API's
The API documentation describes the API contract. The API implementation should match this contract.
It can be found at `/docs/api/ooh-interview-api-swagger.yaml`

## Testing
### API Testing
All tests are located in the `/Tests` folder.

#### Unit Tests
Unit tests are located in the `UnitTests` subfolder.\
They are written in xUnit and use Moq.

Unit tests test only a single component at a time, with all dependencies mocked.

#### Integration Tests
Integration tests are located in the `IntegrationTests` subfolder.\
They are written in xUnit and use the .NET Core integration testing framework.

Integration tests test the whole system at once via the API, with any external dependencies mocked.

## UI Testing
### Unit Tests
All tests are located with their corresponding implementation file.