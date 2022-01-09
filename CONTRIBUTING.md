# Contributing to the Practice Fusion MME Calculator

Thank you for your interest in contributing to this project. From commenting on issues, to reviewing and sending Pull Requests, all contributions are welcome.

The [Open Source Guides](https://opensource.guide/) website has a collection of resources for anyone who wants to learn how to [contribute to open source projects](https://opensource.guide/how-to-contribute/), along with a lot of other valuable information on open source.

As a reminder, all contributors are expected to adhere to the [Code of Conduct](https://github.com/practicefusion/mmecalculator/blob/master/CODE-OF-CONDUCT.md).

## Ways to Contribute
 
1. Contribute fixes, improvements and documentation
2. Replying to and assisting with open issues
3. Reviewing pull requests
4. Provide improved test data
5. Clinical analysis of results, and identification of gaps

## Development Process

We use GitHub issues and pull requests to track bugs and contributions from the community, including Practice Fusion engineers. All changes are handled through pull requests, and before they are approved, the changes must meet the standards outlined in the [Contributing Code](#contributing-code) section below, including a review by Practice Fusion clinicians if there are any changes that might affect the clinical nature of the calculation results.

### Changing Parsing Rules

Changes to the grammar require care and a lot of testing. Please follow the [guidelines](./src/Grammar/) when planning and developing grammar changes.

### Testing 

Code coverage is generated using [Coverlet](https://github.com/coverlet-coverage/coverlet). We aim for more than 90% coverage, with the exclusions documented in the [coverlet runsettings](./src/coverlet.runsettings) file.

## Versioning Process

We use MinVer.

## GitHub Issues

## Helping with Documentation

## Workflow

Code-level contributions must be made through pull requests. This is done by forking the repository, making the changes locally, and using the testing projects to validate the changes you've made.

We recommend using the following workflow:

1. Fork the repository and create a branch from dev
2. Make your changes, and add tests for your changes (see the section on [Testing](#testing) above)
3. For any changes to APIs, update the documentation in the code
4. Make sure all tests pass
5. Make sure your code meets the code standards in `.editorconfig`
6. Push the changes to your fork
7. Create a pull request to the Calculator repository
8. Review and address comments on your pull request