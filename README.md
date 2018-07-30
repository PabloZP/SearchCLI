# SearchCLI
Search words entered in search engines and compare number of results.

The executable file ChallengeCLI.exe is in the folder:  ChallengeCLI\bin\Debug
In the command line ( User must type:

ChallengeCLI <list of queries to search> 

Elements must be separated by spaces.
There must be enteres at least 2 elements (in order to make a comparison)
An element can contain 2 or more words if they are inside double quotes
Examples of Command Line Interface:
  ChallengeCLI Java .Net     -> 2 elemenst
  ChallengeCLI "C Sharp" Python Perl    -> 3 elements
  ChallengeCLI Javascript "Ruby on Rails" Pascal   -> 4 elements
  
  Besides the CLI project, just as a plus, the solution includes a desktop project.
  Both projects call the core whih is in business layer called "BL"
  
  In the BL layer there are 2 main classes.
  Texto class: perform all the parsing of text entered by user.
  Searching class: perform the searches and the calculations on the list of elements entered.
  
 Solution is in C#.
 It shows some programmkhg concepts like Polymorphism.
 Modularity, inheritance, etc.

The first search engine used is Google.
I got an API key and context id. But according the Google's rules the number of results are constrained to 10 results.
So I mocked the existing results with some random functions to avoid that getting always 10 as number of results in order to make sense for the comparison.
Anyway the complete code how I call the Google API can be seen in the GoogleEngine class.

Then I tried the second search engine: I tried yahoo, bing and yandex but there was not possibly, due to lack of documentation or by asking my credit card number to get an API Key.
So I mock results of Yahoo by some random functions.

At the end the 2 search engines show results and a comparison is shown.
