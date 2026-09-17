# Research: Test Vocacional Interactivo

## Tech Stack & Architecture
- **Decision**: Use ASP.NET Core MVC with .NET 8, EF Core with SQL Server.
- **Rationale**: Mandated by the project Constitution and the strict technology stack requirements.
- **Alternatives considered**: None. The constitution is strict.

## Testing Strategy
- **Decision**: Use MSTest for unit tests and Testcontainers for SQL Server integration tests.
- **Rationale**: Mandated by the project Constitution. Testcontainers provides isolated environments for integration tests.

## Frontend Interaction
- **Decision**: Vanilla JavaScript with Fetch API for AJAX requests, and Bootstrap 5 for UI styling (Cards).
- **Rationale**: Constitution forbids React, Angular, and Vue. Vanilla JS is required for the swipe interactions.
