# Repository Guidelines

## Project Structure & Module Organization

`TaheriShop.sln` organizes a layered ASP.NET Core application targeting .NET 10:

- `src/api/TaheriShop.WebApi` is the HTTP entry point and composition root.
- `src/application` contains application services; `Application.Contract` holds public contracts.
- `src/domain` contains business rules; `Domain.Contract` defines domain-facing abstractions.
- `src/infrastructure/TaheriShop.Persistence.EF` is reserved for Entity Framework persistence.
- `src/00-framework` contains reusable cross-cutting abstractions and implementations.
- `tests/TaheriShop.Domain.UnitTests` contains domain unit tests.

Keep dependencies directed inward: API and infrastructure may depend on application/domain contracts, while domain code should not depend on API or persistence projects.

## Build, Test, and Development Commands

Run commands from the repository root:

```bash
dotnet restore TaheriShop.sln
dotnet build TaheriShop.sln --configuration Release
dotnet test TaheriShop.sln
dotnet run --project src/api/TaheriShop.WebApi
dotnet format TaheriShop.sln --verify-no-changes
```

Restore downloads NuGet dependencies; build compiles every project; test runs the xUnit suite. The API uses the URLs in `launchSettings.json` during local development.

## Coding Style & Naming Conventions

Use four-space indentation and standard C# formatting. Nullable reference types and implicit global usings are enabled. Use `PascalCase` for types, methods, and public members; `camelCase` for parameters and locals; prefix interfaces with `I`. Match namespaces to project and folder names, and keep one primary type per file. Prefer small, dependency-injected services and place interfaces in the appropriate `*.Contract` or abstractions project.

## Testing Guidelines

Tests use xUnit, FluentAssertions, and Coverlet. Name test classes after the subject, such as `OrderTests`, and methods by behavior, such as `Create_WithEmptyItems_ShouldFail`. Keep unit tests deterministic and independent of databases, clocks, and networks; inject abstractions such as `IDateTimeService`. Run coverage when needed with:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

No coverage threshold is currently enforced; add tests for every business-rule change.

## Commit & Pull Request Guidelines

History currently contains only an `Initial commit`, so no formal convention is established. Use short, imperative subjects, for example `Add order total validation`, and keep unrelated changes separate. Pull requests should explain intent, list verification commands, link relevant issues, and call out API, schema, or configuration changes. Include sample requests or screenshots when behavior visible to API consumers changes.

## Security & Configuration

Never commit secrets, certificates, connection strings, or local environment files. Store developer overrides in ignored `appsettings.*.local.json` files or .NET user secrets, and document any required configuration keys in the pull request.
