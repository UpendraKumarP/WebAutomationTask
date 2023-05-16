# WebAutomationTask

Implementation Details:
======================
Step1: Created a SpecFlow Project in Visual Studio using XUnit (for inbuilt parallel execution feature).

Step2: Added Nuget packages for "Selenium.Support", "ChromeDriver" and build the solution

Step3: Removed Default Calculator feature and StepDefinition files and added WebAutomationTask feature file,
Corresponding StepDefinitions, PagesObjects, BrowserDrivers

Step4: Here is the solution I followed to implement given task

1.Launched the application url

2. Used Mouse Actions to hover over the products and to add to the cart

3.Also Used Random function to not to repeat the cart items(i.e To not to add same item more than once)

4.Then opened the cart and identified the quantity of each item to calculate sum of items in cart

5.Then Used List Sort technique to find lowest priced item in the cart and removed the item

6.Finally waited for removed message and validated the remaining items in the cart

7.Added 2 invalid scenarios too in the feature file to confirm if code validating correctly

Step5: Created a git repository from visual studio and push the changes to the git hub


Execution Details:
==================
1. Clone the poject into local repository

2. Have the necessary Nuget packages "Selenium Support", "ChromeDriver"

3. Build the solution using Build menu

4. Run All tests using Test Explorer