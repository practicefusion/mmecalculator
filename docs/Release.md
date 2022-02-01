# How to Release

We use the [release](https://github.com/practicefusion/mmecalculator/blob/main/.github/workflows/release.yml) action for releases.

We use [MinVer](https://github.com/adamralph/minver) to version the project. 

## Pre-releases

1. Create a new version branch (e.g. 'v1.2.0')
2. Tag the branch with a pre-release tag (e.g. 'v1.2.0-alpha.0), and push
3. The release action will upload the pre-release package to Nuget

## Releases

1. When a branch is ready to be released, take the branch with the release tag (e.g. 'v1.2.0') and push
2. The release action will upload the release package to Nuget