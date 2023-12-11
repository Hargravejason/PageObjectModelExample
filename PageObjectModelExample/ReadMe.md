
Selenium Edge Web driver:
	Need to have the edge web driver in the project directory for Visual Studio to locate, or in a shared location
	
	https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/#downloads

Be mindful Google doesn't like automated input on their site, this is a simple demonstration of how automated testing can be used with any website and how to simplify development of tests using a Page Object Model (POM).

Thought process is the following:
	
	•  Develop Page Object Models for each page or process that will be maintained as the code is developed or changed over time
	•  Tests are created targeting the POM properties and functions not specific items on the page
		 •  This is done so the tests do not need to be changed if the page changes, the POM will be updated and the tests will stay the same, unless they need to be updated for feature or the test case changes over all

Doing it in this fashion helps protect tests that do not need to be updated for a feature change, as long as no major changes to the POM/Page then the test should be able to run without any updates.

You can also create functions that perform complex clicks or edits that a test can call. Such as common data entry.

