using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpecFlowPA.PageObjects
{
    public class PageForm
    {

        public static IWebDriver WebDriver { get; private set; }

        private readonly IWebElement searchField;
        private readonly IWebElement searchButton;
        private readonly IWebElement item;
        private readonly IWebElement addItem;
        private readonly IWebElement proceedButton;
        
    

        public PageForm(IWebDriver driver)
        {
            WebDriver = driver;
            searchField = driver.FindElement(By.XPath("//*[@id='search_query_top']"));
            searchButton = driver.FindElement(By.XPath("//*[@name='submit_search']"));
            item = driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/h5/a"));
            addItem = driver.FindElement(By.XPath("//*[@title='Add to cart']"));
            proceedButton = driver.FindElement(By.XPath("//*[@title='Proceed to checkout']"));
            

        }

        public void SearchText(string text)
        {
            searchField.SendKeys(text);
        }

        public void EnterSearchText()
        {
            SearchText("Dresses");
        }

        public void clickSearch()
        {
            searchButton.Click();
        }

        public void HoverOverItem()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(item);
            
        }

        public void ClickAddToCart()
        {
            addItem.Click();
        }

        
    }
}
