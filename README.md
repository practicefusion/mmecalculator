[![CI](https://github.com/practicefusion/mmecalculator/actions/workflows/ci.yml/badge.svg)](https://github.com/practicefusion/mmecalculator/actions/workflows/ci.yml)

# Practice Fusion MME Calculator
> Morphine Milligram Equivalent (MME) Calculator: APIs, Containers and Samples

The calculator accepts two parameters: 

1. the [RxNorm](https://www.nlm.nih.gov/research/umls/rxnorm/overview.html) RxCUI (the drug identifier), which is used to retrieve the RxNorm normalized drug name
2. the *sig*, free-text instructions from the prescriber or pharmacist indicating how the patient should use the medication

The *sig* is used to establish a maximum or total daily dose. The normalized drug name is used to identify active opioids and their strengths, so that a total daily dose in milligrams (or the appropriate unit of measure) can be established. Finally, using the appropriate [conversion factor](https://www.hhs.gov/guidance/sites/default/files/hhs-guidance-documents/Opioid%20Morphine%20EQ%20Conversion%20Factors%20%28vFeb%202018%29.pdf), which sometimes requires additional information on the route or form of the drug, a maximum morphine milligram equivalence per day is calculated.

The result is returned along with analysis of the medications and sigs. The analysis breaks down the parsed and calculated information, and includes a confidence rating on the information, along with any explanation of failures. Currently, if there are any failures, the calculator returns a "no-confidence" result.

The calculator makes no recommendations regarding the [safety of the maximum MME per day](https://www.cdc.gov/drugoverdose/pdf/calculating_total_daily_dose-a.pdf), that is instead left up to calling services (like clinical decision support services), which should analyze the calculated result and the confidence of the calculation before making a recommendation.

## Installing / Getting started

### Installing the [NuGet Package](https://www.nuget.org/packages/PracticeFusion.MmeCalculator.Core)
To use the calculator in your own project, add the package:
```
dotnet add package PracticeFusion.MmeCalculator.Core
```
See the sample CLI for more information on how to use the calculator.

### Running the web demo in a docker image
1. From the `src` directory, run:
```
$ docker build -f Samples/PracticeFusion.MmeCalculator.WebDemo/Dockerfile . -t mmewebdemo
$ docker run -d -p 80:80 --name mmewebdemo mmewebdemo
```
2. Browse to http://localhost/ to see the demo
3. Browse to http://localhost/docs to view the api documentation.

### Running the sample CLI in a docker image
1. From the `src` directory, run:
```
$ docker build -f Tools/PracticeFusion.MmeCalculator.Cli/Dockerfile . -t mmecli
```
2. Run an instance to see the help:
```
$ docker run -i --rm mmecli --help

Usage:
  mmecalculator [options] [command]

Options:
  -i, --input <input>                                 input file (if not present, will use stdin)
  -o, --output <output>                               output file (if not present, will use stdout)
  -ow, --overwrite                                    overwrite the output file if it exists [default: False]
  -of, --outputFormat <Basic|Debug|DebugFormatted>    output format (basic, debug) [default: Basic]
  --version                                           Show version information
  -?, -h, --help                                      Show help and usage information

Commands:
  calculate
  parsesig
  antlrperf
```

## How to Contribute

We want to make contributing to this project as simple as possible, and we are grateful to the community for contributing bug fixes, feature requests and code improvments. Read below to learn how you can take part in improving the MME calculator.

### Bug reports

To report a bug [click here](https://github.com/practicefusion/mmecalculator/issues/new?assignees=&labels=&template=bug_report.md&title=) and fill in the template. We'll look at it as soon as we can.

### Feature Requests

To  request a new feature [click here](https://github.com/practicefusion/mmecalculator/issues/new?assignees=&labels=&template=feature_request.md&title=) and fill in the template.

### Contributing Guide

Read our [Contributing Guide](https://github.com/practicefusion/mmecalculator/blob/master/CONTRIBUTING.md)

### [Code of Conduct](https://github.com/practicefusion/mmecalculator/blob/master/CODE-OF-CONDUCT.md)
We have adopted a Code of Conduct that we expect project participants to adhere to. Please read the [full text](https://github.com/practicefusion/mmecalculator/blob/master/CODE-OF-CONDUCT.md).

## Links

- Project homepage: https://github.com/practicefusion/mmecalculator
- Issue tracker: https://github.com/practicefusion/mmecalculator/issues
  - In case of sensitive bugs like security vulnerabilities, please contact [security@practicefusion.com](mailto:security@practicefusion.com) directly instead of using the issue tracker. We value your effort to improve the security and privacy of this project!
- Special thanks to the following:
  - [Dr. David Hurwitz](https://github.com/dphurwitz), [Dr. Geoff Caplea](https://github.com/gcapmd), [Ken Sheppard](https://github.com/ken-sheppard), [Alex Dove](https://github.com/ardove), [Jeff Carter](https://github.com/codecarter9)
  - Dr. Ken Kawamoto (via support from contracts HHS 75P00119F80176 and HHS 75P00120F80182 managed by Security Risk Solutions, Inc.), and the sig parsing for the [OpenCDS project](https://bitbucket.org/opencds/fhir-utils/src/master/src/main/java/org/opencds/RxSig.java).
  
## Maintainers

[@JonathanMalek](https://github.com/JonathanMalek)

## License

The Practice Fusion MME Calculator is licensed under the [MIT license](https://github.com/practicefusion/mmecalculator/blob/main/LICENSE).
