using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using NUnit.Framework;
using SpecFlowPA.PageObjects;

namespace SpecFlowPA.StepDefinitions
{
    [Binding]
    
    public class DressesSearch_FeatureStepDefinitions
    {
        public readonly IWebDriver driver = new ChromeDriver(@"C:\Users\8912.ARDIANET\source\repos\SpecFlowPA\SpecFlowPA\Drivers");

        [Given(@"the user is on the home page")]
        public void GivenTheUserIsOnTheHomePage()
        {
            
            driver.Url = "http://automationpractice.com/index.php";
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='search_query_top']")));

        }

        [When(@"I have entered Dresses in the search field")]
        public void WhenIHaveEnteredDressesInTheSearchField()
        {
            var form = new PageForm(driver);
            form.EnterSearchText();
          
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            var form = new PageForm(driver);
            form.clickSearch();
           
        }

        [Then(@"the results page for Dresses is displayed")]
        public void ThenTheResultsPageForDressesIsDisplayed()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            fluentWait.Until(x => x.FindElement(By.XPath("//*[@class='page-heading  product-listing']")));

            var actualResult = driver.FindElement(By.XPath("//*[@class='lighter']")).Text;
            var expectedResult = "\"DRESSES\"";

            Assert.AreEqual(expectedResult, actualResult.ToString());
            driver.Close();
        }

    }
}
