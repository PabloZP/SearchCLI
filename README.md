# SearchCLI
Search words entered in search engines and compare number of results.

User must type ChallengeCLI <list of queries to search>
Elements must be separated by spaces.
There must be enteres at least 2 elements (in order to make a comparison)
An element can contain 2 or more words if they are inside double quotes
Examples of Command Line Interface:
  ChallengeCLI Java .Net     -> 2 elemenst
  ChallengeCLI "C Sharp" Python Perl    -> 3 elements
  ChallengeCLI Javascript "Ruby on Rails" Pascal   -> 4 elements
  
  Besides the CLI project, the solution includes a desktop project.
  Both projects call the core whih is in business layer called "BL"
  
 Solution is in C#.
 It shows some programmkhg concepts like Polymorphism.
 Modularity, inheritance, etc.

The first search engine used is Google.
I got an API key and context id. But according the Google's rules the number of results are constrained to 10 results.
So I mocked existing results with some random functions to avoid that getting always 10 as number of results in order to make sense  for the comparison.
Anyway the complete code how I call the Google API canbe seen in the GoogleEngine class.

The I tried the second search engine. I tried yahoo, bing and yandex but there was not possibly, due to lack of documentation or by asking my credit card number to get an API Key.
So I mock results of Yahoo by some randk functions.

At the end the 2 search engines shows results and a comparison is shown.
