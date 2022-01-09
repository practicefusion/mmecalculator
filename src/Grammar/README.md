# Working with the MME Calculator Grammar

The MME Calculator uses an [ANTLR4](https://www.antlr.org/) grammar, defined in separate *Parser.g4 and *Lexer.g4 files in [src/Grammar](../Grammar/). ANTLR4 is used to generate the files in the [Generated](../PracticeFusion.MmeCalculator.Core/Parsers/Generated/) directory of the core project.

## **Important**: Before Making Changes

Changes to the grammar can have far-reaching consequences, and must be made very carefully. It is important to discuss your proposed changes with the maintainers of the project before making changes. PRs with grammar changes that have not yet been discussed will almost certainly be rejected.

## Configuring Your Environment for Editing

1. Install a JRE, for instance:
```
winget install -e --id Oracle.JavaRuntimeEnvironment
```
2. Install [Visual Studio Code](https://code.visualstudio.com/)
3. In Visual Studio Code, add the extension [ANTLR4 grammar syntax support](https://marketplace.visualstudio.com/items?itemName=mike-lischke.vscode-antlr4)

## Modifying the Grammar

1. Open the `src/Grammar` directory in Visual Studio Code
2. Open either of the *.g4 files, and save the file without making changes, in order to generate the output files
3. Confirm that the `src/Grammar/.csharp-output` directory contains the generated files
4. Modify the parser or lexer files as necessary

## Testing the Grammar

1. Modify [parser-test-input.txt](./parser-test-input.txt) as necessary to create a test sig
2. Use Visual Studio Code debugging (F5) to test the parser and view the tree of results
3. Unless absolutely necessary, changes to the test file should not be pushed
4. Ensure *all* existing system and unit tests pass, and add tests for any new parser or lexer rules

## Upgrading to future versions of ANTLR

We currently use ANTLR v4.9.2. The jar file is included in the `src/Grammar` folder, and is referenced in [settings.json](./.vscode/settings.json):

```
    "alternativeJar": "antlr-4.9.2-complete.jar"
```

This setting enables the ANTLR VS Code extension to use a specific version of ANTLR for generating output.

To update to a future version of ANTLR, ensure that it is included in the directory, and that the `settings.json` file is updated.

Consideration should be given to updating the ANTLR dependency in the Core project as well.