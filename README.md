# _Word Base_

#### _Strategy Game that is a mix of Scrabble and Go, 3-8-2018_

#### By _**Jasun Feddema, Ian Goodrich, Sara Hamilton, Frank Ngo**_

## Rules

* The objective is to reach your opponent's base squares (striped in their color), with a chain of letters, before they reach your base.
* Starting from one of the letter squares in your color, spell out a word using letters in neighboring squares, connecting squares in any direction including diagonally. These squares are now yours.
* You can claim your opponent's squares by playing on them.
* If you cut your opponent's chain by playing across it so some squares are no longer connected back to their owner's base, those squares will go white again.
* You win when you claim one or more squares in your opponent's base.
* A word can only be played once in each game (not once by each player).
* No proper nouns (names, places etc - anything that usually starts with a capital letter).

## Setup/Installation Requirements

* _Clone this GitHub repository_

```
git clone https://github.com/LeeMellon/WordBase.git
```

* _Install the .NET Framework and MAMP_

  .NET Core 1.1 SDK (Software Development Kit)

  .NET runtime.

  MAMP

  See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

  * _Start the Apache and MySql Servers in MAMP_

*   _Setup the database_

  Create a database named wordbase

  Import the SQL dictionary that is included in this GitHub repository into the wordbase database.

* _Run the program_
  1. In the command line, cd into the project folder.
  ```
  cd Wordbase.Solution
  ```
  2. In the command line, type 'dotnet restore'. Enter to install the required software packages.  It make take a few minutes to complete this process.
  ```
  dotnet restore
  ```
  3. In the command line, type 'dotnet build'. Any error messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When message says Build succeeded in green, proceed to the next step.
  ```
  dotnet build
  ```
  4. In the command line, type 'dotnet run' Enter.
  ```
  dotnet run
  ```

* _View program on web browser at port localhost:5000/_

* _Follow the prompts._

## Testing

* _Start the Apache and MySql Servers in MAMP_

*   _Setup the database_  

Create a database named wordbase_test  

Import the SQL dictionary that is included in this GitHub repository into the wordbase_test database.

See https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/database-practice-and-world-data for instructions and links explaining how to download the file that is located inside this github repository.

* _Run the program_
  1. In the command line, cd into the project folder.
  ```
  cd Wordbase.Solution
  cd Wordbase.Tests
  ```
  2. In the command line, type dotnet restore. Enter.  It make take a few minutes to complete this process.
  ```
  dotnet restore
  ```
 3. In the command line, type dotnet test. Enter. The tests will run.  When the tests are finished, output stating how many tests were run, how many tests passed, and how many tests were skipped will be displayed.  If any tests fail, details about the failures will be described in the console.  
  ```
  dotnet test
  ```

## Known Bugs

_There are no know bugs_

## Support and contact details


_To suggest changes, submit a pull request in the GitHub repository._

## Technologies Used

* HTML
* Bootstrap
* C#
* .Net Core 1.1
* Javascript
* JQuery 3.3.1

*MIT License*

Copyright (c) 2018 **_Jasun Feddema, Ian Goodrich, Sara Hamilton, Frank Ngo_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
