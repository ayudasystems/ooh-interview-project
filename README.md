# OOH Interview Project
This repository contains a simple UI and API for selling inventory in OOH (Out of Home) Advertising.\
The candidate will complete a variety of tasks to improve the system and demonstrate their knowledge.

## Tasks
Please view the list of tasks at `/TODO`.

It's not expected that all tasks are completed.
It's better to do a few tasks well than a lot of tasks rushed.

The tasks cover both UI and API.\
Tasks related to Campaigns are generally more UI focused, and tasks related to Faces are generally more API focused.\
You may choose to do whichever ones you think demonstrate your skillset the best. 

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
The API requires documentation to be written before development.\
The API Definition can be found at `/docs/api/ooh-interview-api-swagger.yaml`

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