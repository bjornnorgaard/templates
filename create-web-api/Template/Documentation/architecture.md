# Solution Projects and Description
The solution is split into some different projects, each with their own responsibilities.

- [Solution Projects and Description](#Solution-Projects-and-Description)
  - [Application](#Application)
  - [Infrastructure](#Infrastructure)
  - [Models](#Models)
  - [Repository](#Repository)
  - [Test.Arrange](#TestArrange)
  - [Test.Integration](#TestIntegration)
  - [Test.Unit](#TestUnit)
  - [Api.Web](#Api.Web)

## Application
Business logic and mediator handlers.

- Where business logic resides.
- Split into features.
- Each feature should be isolated from eachother.

## Infrastructure
General plumbing for solution.

- Configures plumbing that is needed by other projects than the WebAPI.
- Contains custom exceptions.

## Models
Domain models

- Database model extensions.

## Repository
Provides data access.

- Configures database representation of models in the `Configurations` folder.
- Manages DbContexts for EF Core.
- Custom Query and context extensions in `Extensions`.
- Contains migrations.

## Test.Arrange
Contains class extensions for common arrange logic.

- Create valid instances in a single location.
- Performs common database setup before transactions.

## Test.Integration
Contains more time consuming tests. Exists as seperate project to allow for seperate runs of 'fast' and 'slow' tests.

- Configures a TestHost for E2E testing.
- Only mocks database, not Repository.

## Test.Unit
Contains unit tests. Should always run fast.

- Also sets up a fake SqLite database.
- Only used for unit tests of single classes.

## Api.Web
Entrypoint for solution.

- Configures Dependancy Injection.
- Contains environment configurations.
- Sets up logging.
- Controllers guard access to Application handlers.
