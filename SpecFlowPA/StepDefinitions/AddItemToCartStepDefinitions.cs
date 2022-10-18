using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SpecFlowPA.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowPA.StepDefinitions
{


    [Binding]
    public class AddItemToCartStepDefinitions
    {
        public readonly IWebDriver driver = new ChromeDriver(@"C:\Users\8912.ARDIANET\source\repos\SpecFlowPA\SpecFlowPA\Drivers");

        [Given(@"I am on the Home page")]
        public void GivenIAmOnTheHomePage()
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

        [Given(@"I  mouse hover over an item")]
        public void GivenIMouseHoverOverAnItem()
        {
            var form = new PageForm(driver);
            form.HoverOverItem();

        }

        [When(@"I click on the add to cart button for an item")]
        public void WhenIClickOnTheAddToCartButtonForAnItem()
        {
            var form = new PageForm(driver);
            form.ClickAddToCart();
        }

        [Then(@"The item is successfully added to the shopping cart")]
        public void ThenTheItemIsSuccessfullyAddedToTheShoppingCart()
        {
            var form = new PageForm(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='layer_cart']/div[1]")));

            Assert.That(driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]")).Enabled);
            driver.Close();
            
        }
    }
}
