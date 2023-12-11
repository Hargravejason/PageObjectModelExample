using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System.Linq;

namespace PageObjectModelExample;


internal class GoogleIndexPOM
{
	private readonly EventFiringWebDriver _driver;

	public GoogleIndexPOM(EventFiringWebDriver driver) => _driver = driver;

	public IWebElement SearchBox => _driver.FindElement(By.CssSelector("form[role='search'] textarea"));
	public IWebElement GoogleSearchButton => _driver.FindElement(By.CssSelector("form[role='search'] input[value='Google Search']"));
	public IWebElement ImFeeling => _driver.FindElement(By.CssSelector("form[role='search'] input[value*='Feeling']"));


	public void Search(string searchText)
	{
		//enter text into the search box
		SearchBox.SendKeys(searchText);

		//click the search
		GoogleSearchButton.Click();
	}
}
