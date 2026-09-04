# Repository Guidelines

## Project Structure & Module Organization

`TaheriShop.sln` organizes a layered ASP.NET Core application targeting .NET 10:

- `src/api/TaheriShop.WebApi` is the HTTP entry point and composition root.
- `src/application` contains application services and public contracts.
- `src/domain` contains business rules and domain-facing contracts.
- `src/infrastructure/TaheriShop.Persistence.EF` is reserved for Entity Framework persistence.
- `src/00-framework/TaheriShop.Framework.Domain` contains reusable DDD building blocks:
  entities, aggregate roots, value objects, event contracts, and rule exceptions.
- `src/domain/TaheriShop.Domain` contains aggregates and events; `Account` raises `AccountCreated`.
- `tests/TaheriShop.Domain.UnitTests` contains xUnit tests, `Builders/AccountBuilder.cs`
  test-object builders, and `Helpers/TestHelper.cs` random test data helpers.

Keep dependencies directed inward: API and infrastructure may depend on application/domain contracts; domain code must not depend on API or persistence.

## Architecture & Domain Conventions

Use framework domain primitives instead of reimplementing identity or event behavior.
Aggregate roots inherit `AggregateRoot<TKey>` and expose state through controlled methods.
Domain events implement `IDomainEvent` (`EventId` and `OccurredOn`) and are added through the
aggregate root. Keep event types beside their aggregate under `src/domain/.../Events`.
Represent invariants with `IBusinessRule` implementations and framework rule helpers.

## Build, Test, and Development Commands

Run commands from the repository root:

```bash
dotnet restore TaheriShop.sln
dotnet build TaheriShop.sln --configuration Release
dotnet test TaheriShop.sln
dotnet run --project src/api/TaheriShop.WebApi
dotnet format TaheriShop.sln --verify-no-changes
```

Restore downloads dependencies; build compiles the solution; test runs the xUnit suite.

## Coding Style & Naming Conventions

Use four-space indentation and standard C# formatting. Nullable reference types and implicit global
usings are enabled. Use `PascalCase` for public symbols, `camelCase` for locals and parameters, and
prefix interfaces with `I`. Match namespaces to folders and keep one primary type per file.

## Testing Guidelines

Tests use xUnit, FluentAssertions, and Coverlet. Name classes after the subject (`OrderTests`) and
methods by behavior (`Create_WithEmptyItems_ShouldFail`). Use builders and `TestHelper` for arrange
data, and assert aggregate state plus emitted events. Keep tests independent of databases, clocks,
and networks; inject abstractions such as `IDateTimeService`. Run coverage with:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

No coverage threshold is enforced; add tests for every business-rule change.

## Commit & Pull Request Guidelines

Use short, imperative commit subjects, for example `Raise account created domain event`, and keep
unrelated changes separate. Pull requests should explain intent, list verification commands, link
issues, and call out API, schema, or configuration changes. Include samples or screenshots when
consumer-visible behavior changes.

## Security & Configuration

Never commit secrets, certificates, connection strings, or local environment files. Use ignored
`appsettings.*.local.json` overrides or .NET user secrets.
