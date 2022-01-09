## Instructions
First, start the "Server". This is a simple application which takes a dependency on the MmeCalculator and hosts a simple rest API to return calculator results (see [CalculatorController.cs](./Server/PracticeFusion.MmeCalculator.Host/Controllers/CalculatorController.cs) for details on how to use the MmeCalculator). It demonstrates how to register the calculator with the DI framework in .NET Core and how to use it in your applciations. 
```
dotnet run --project Server/PracticeFusion.MmeCalculator.Host/PracticeFusion.MmeCalculator.Host.csproj
``` 

Next, open up a new console window and fire up the console application. This just makes a simple HTTP request to the Server that you just started and writes the results to the console. 
```
dotnet run --project Client/PracticeFusion.MmeCalculator.Console/PracticeFusion.MmeCalculator.Console.csproj 1049647 "take 1 tablet bid prn chronic pain" 1049647 "take 1 tablet tid prn chronic pain"
```

Note that you may need to tweak the server uri used in the console application depending on how you ran the server (Following the steps here, you should change it to http://localhost:5000 -- see [Program.cs](./Client/PracticeFusion.MmeCalculator.Console/Program.cs#L40) for more details). Note that the Console application takes a repeating set of arguments -- an rxcui followed by a medication sig (as many times as you want). 

If you used the existingYou should see a response that looks like the following
```
{
  "RequestId": "618f544d-de38-4a64-b2d0-3fad95852fc5",
  "CalculatedResultAnalysis": {
    "MaximumMmePerDay": 0,
    "Opioids": [],
    "Confidence": "None",
    "ConfidenceReasons": [
      "Not all parsed results high confidence"
    ]
  },
  "ParsedResults": [
    {
      "RequestItemId": "1",
      "ParsedMedication": {
        "OriginalMedication": "",
        "PreprocessedMedication": "",
        "RxCui": "1049647",
        "MedicationComponents": [],
        "Confidence": "None",
        "ConfidenceReasons": []
      },
      "ParsedSig": {
        "OriginalSig": "take 1 tablet bid prn chronic pain",
        "PreprocessedSig": "take 1 tablet bid prn chronic pain",
        "MaximumDosage": {
          "MinDose": 2,
          "MaxDose": 2,
          "Complex": false,
          "DoseUnit": {
            "Form": {
              "ValueEnum": "Tablet",
              "Index": 7,
              "Length": 6
            },
            "Index": 7,
            "Length": 6
          },
          "HumanReadable": "2 tablets",
          "Index": 0,
          "Length": 0
        },
        "Dosages": [
          {
            "Confidence": "None",
            "ConfidenceReasons": [],
            "Dose": {
              "MinDose": 1,
              "MaxDose": 1,
              "Complex": false,
              "DoseUnit": {
                "Form": {
                  "ValueEnum": "Tablet",
                  "Index": 7,
                  "Length": 6
                },
                "Index": 7,
                "Length": 6
              },
              "HumanReadable": "1 tablet",
              "Index": 5,
              "Length": 8
            },
            "Frequency": {
              "Freq": 2,
              "FreqMax": 2,
              "Period": 1,
              "PeriodMax": 1,
              "PeriodUnit": "Day",
              "FrequencyEnum": "TwoTimesADay",
              "Index": 14,
              "Length": 3
            },
            "AsNeeded": {
              "Instruction": "chronic pain",
              "Index": 18,
              "Length": 16
            },
            "HumanReadable": "1 tablet 2 times every day as needed for chronic pain",
            "Index": 5,
            "Length": 29
          }
        ],
        "Confidence": "None",
        "ConfidenceReasons": []
      },
      "MaximumMmePerDay": 0,
      "MaximumDailyDose": {
        "MinDose": 2,
        "MaxDose": 2,
        "Complex": false,
        "DoseUnit": {
          "Form": {
            "ValueEnum": "Tablet",
            "Index": 7,
            "Length": 6
          },
          "Index": 7,
          "Length": 6
        },
        "HumanReadable": "2 tablets",
        "Index": 0,
        "Length": 0
      },
      "Confidence": "None",
      "ConfidenceReasons": [
        "Failed to find the medication",
        "Sig not high confidence",
        "Medication not high confidence"
      ]
    },
    {
      "RequestItemId": "2",
      "ParsedMedication": {
        "OriginalMedication": "",
        "PreprocessedMedication": "",
        "RxCui": "1049647",
        "MedicationComponents": [],
        "Confidence": "None",
        "ConfidenceReasons": []
      },
      "ParsedSig": {
        "OriginalSig": "take 1 tablet tid prn chronic pain",
        "PreprocessedSig": "take 1 tablet tid prn chronic pain",
        "MaximumDosage": {
          "MinDose": 3,
          "MaxDose": 3,
          "Complex": false,
          "DoseUnit": {
            "Form": {
              "ValueEnum": "Tablet",
              "Index": 7,
              "Length": 6
            },
            "Index": 7,
            "Length": 6
          },
          "HumanReadable": "3 tablets",
          "Index": 0,
          "Length": 0
        },
        "Dosages": [
          {
            "Confidence": "None",
            "ConfidenceReasons": [],
            "Dose": {
              "MinDose": 1,
              "MaxDose": 1,
              "Complex": false,
              "DoseUnit": {
                "Form": {
                  "ValueEnum": "Tablet",
                  "Index": 7,
                  "Length": 6
                },
                "Index": 7,
                "Length": 6
              },
              "HumanReadable": "1 tablet",
              "Index": 5,
              "Length": 8
            },
            "Frequency": {
              "Freq": 3,
              "FreqMax": 3,
              "Period": 1,
              "PeriodMax": 1,
              "PeriodUnit": "Day",
              "FrequencyEnum": "ThreeTimesADay",
              "Index": 14,
              "Length": 3
            },
            "AsNeeded": {
              "Instruction": "chronic pain",
              "Index": 18,
              "Length": 16
            },
            "HumanReadable": "1 tablet 3 times every day as needed for chronic pain",
            "Index": 5,
            "Length": 29
          }
        ],
        "Confidence": "None",
        "ConfidenceReasons": []
      },
      "MaximumMmePerDay": 0,
      "MaximumDailyDose": {
        "MinDose": 3,
        "MaxDose": 3,
        "Complex": false,
        "DoseUnit": {
          "Form": {
            "ValueEnum": "Tablet",
            "Index": 7,
            "Length": 6
          },
          "Index": 7,
          "Length": 6
        },
        "HumanReadable": "3 tablets",
        "Index": 0,
        "Length": 0
      },
      "Confidence": "None",
      "ConfidenceReasons": [
        "Failed to find the medication",
        "Sig not high confidence",
        "Medication not high confidence"
      ]
    }
  ]
}
```