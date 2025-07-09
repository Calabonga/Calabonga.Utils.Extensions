# Calabonga.Utils.Extensions

Some helpful extensions for C#.NET. [Nuget-package](https://www.nuget.org/packages/Calabonga.Utils.Extensions) contains extensions (C#) that can simplify developer life.

## Change History

### 1.5.1 2025-07-09

* Some extensions added for `SemanticVersion` display formats.
* A few unit-tests added.

### 1.5.0 2025-07-08

* Custom `Regex` parsing for `SemanticVersion` added with some unit-tests.

### 1.4.0 2025-07-07

* SemVer parsing and extraction from assembly removed.

### 1.3.0 2025-07-04

* SemVer parsing and extraction from assembly added.

### 1.2.0 2025-06-22

There are new extensions for `DateTime` added:
* `.ToJiraString()` => `1d 4h 34m 23s`
* `.GetMonthStartDay()` => return the first day of the month
* `.GetMonthStartDay()` => return the first day of the month
* `.GetWeekStartDay()` => return the first day of the week
* `.GetWeekEndDay()` => return the last day of the week

### 1.1.0

* `Random()`, `Randomized()` and `Randoms()` method for LINQ released.

### 1.0.2

* `WithIndex` method added to `EnumerableExtensions`