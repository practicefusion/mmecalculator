# How to Build

We use the [CI](https://github.com/practicefusion/mmecalculator/blob/main/.github/workflows/ci.yml) action for continuous builds.

You can build and test locally:

```
$ dotnet build --configuration Release src/MmeCalculator.sln
$ dotnet test src/Test/PracticeFusion.MmeCalculator.UnitTests
```

To run the system tests:

```
$ dotnet test src/Test/PracticeFusion.MmeCalculator.SystemTests
```

## Whitesource

We use [Whitesource for GitHub.com](https://github.com/apps/whitesource-for-github-com) to scan this repo for vulnerable OSS libraries.

## CodeQL

We use [CodeQL](https://codeql.github.com/) to analyze the repository for security vulnerabilities. The [codeql action](https://github.com/practicefusion/mmecalculator/blob/main/.github/workflows/codeql-analysis.yml) is run on PRs and pushes in this repository.