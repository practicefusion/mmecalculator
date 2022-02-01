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