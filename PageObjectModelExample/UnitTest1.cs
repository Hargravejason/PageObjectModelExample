using NUnit.Framework.Legacy;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.Events;

namespace PageObjectModelExample
{
	[TestFixture]
	public class Tests
	{
		private EventFiringWebDriver _driver;

		[SetUp]
		public void Setup()
		{
			//create options for the edge driver
			var options = new EdgeOptions
			{
				PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Normal
			};

			//setup the edge driver, we use the EventFiringWebDriver driver to wrap so we can catch events if needed 
			_driver = new EventFiringWebDriver(new EdgeDriver(options));

			//maximize the window
			_driver.Manage().Window.Maximize();

			//set the default timeout to 30 seconds as needed
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

			//tie in the event collector to be used later
			_driver.Navigated += _driver_Navigated;
		}

		[TearDown] public void Teardown()
		{
			//close down the browser/driver
			_driver.Quit();

			//dispose of the driver
			_driver.Dispose();
		}

		private void _driver_Navigated(object? sender, WebDriverNavigationEventArgs e)
		{
			//setup any items that depend on navigation
		}

		[TestCase("Selenium", Author = "Jason Hargrave", Description = "Example of performing a Google Search with Selenium using a Page Object Model process")]
		[TestCase("Selenium Edge WebDriver", Author = "Jason Hargrave", Description = "Example of performing a Google Search with Selenium using a Page Object Model process - showing how NUnit allows parameterized test cases")]
		public void Test1(string lookup)
		{
			//navagate
			_driver.Url = "https://www.google.com";

			//setup our Page Object Model (POM)
			var googlePOM = new GoogleIndexPOM(_driver);

			//enter text into the search box
			googlePOM.SearchBox.SendKeys(lookup);

			//click the search
			googlePOM.GoogleSearchButton.Click();

			//verify the updated screen has the text we looked for
			Assert.That(googlePOM.SearchBox.Text, Is.EqualTo(lookup));

			//verify the title at the top has it as well
			StringAssert.Contains(lookup, _driver.Title);
		}

		[TestCase("NUnit", Author = "Jason Hargrave", Description = "Example of performing a Google Search with Selenium using a Page Object Model process with a complex function to perform actions")]
		public void Test2(string lookup)
		{
			//navagate
			_driver.Url = "https://www.google.com";

			//setup our Page Object Model (POM)
			var googlePOM = new GoogleIndexPOM(_driver);

			//perform the complex action - this can be multiple steps as needed
			googlePOM.Search(lookup);

			//verify the updated screen has the text we looked for
			Assert.That(googlePOM.SearchBox.Text, Is.EqualTo(lookup));

			//verify the title at the top has it as well
			StringAssert.Contains(lookup, _driver.Title);
		}
	}
}