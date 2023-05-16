using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.CommonModels;
using TechTalk.SpecFlow.Infrastructure;

namespace WebAutomationTask.PageObjects
{
    public class ShoppingCartPageObject
    {
        private const string ShoppingCartUrl = "https://cms.demo.katalon.com/";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public ShoppingCartPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IList<IWebElement> Products => _webDriver.FindElements(By.XPath("//ul/li[contains(@class,'product')]//a[contains(text(),'Add to cart')]"));
        private IWebElement CartLink => _webDriver.FindElement(By.XPath("//a[text()='Cart']"));
        private IList<IWebElement> CartProductQuantities => _webDriver.FindElements(By.XPath("//input[contains(@id,'quantity')]"));
        private IList<IWebElement> CartProductPrices => _webDriver.FindElements(By.XPath("//td[@class='product-price']"));
        private IWebElement RemoveMessage => _webDriver.FindElement(By.XPath("//div[@class='woocommerce-message']"));
        public void OpenPage() {
            _webDriver.Navigate().GoToUrl(ShoppingCartUrl);
        }

        public void AddItemsToTheCart(int NumberOfItems) {
            Random Random = new Random();
            HashSet<int> RandomItems = new HashSet<int>();
            while (RandomItems.Count < NumberOfItems) {
                RandomItems.Add(Random.Next(1, Products.Count));
            }
          
            foreach(int Item in RandomItems)
            {
             new Actions(_webDriver).ScrollToElement(Products[Item]).Perform();
             new Actions(_webDriver).MoveToElement(Products[Item]).Click().Perform();

            }
        }

        public void ScrollToThePageTop() {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
        }

        public void OpenTheCart() {
            ScrollToThePageTop();
            CartLink.Click();
        }

        public int TotalQuantityInTheCart() {
            int TotalQuanity = 0;
            foreach(IWebElement Quantity in CartProductQuantities) {
                TotalQuanity= TotalQuanity+int.Parse(Quantity.GetAttribute("value"));
            }
            return TotalQuanity;
        }

        public void removeLowestPricedItem() {
            List<double> Prices = new List<double>();
            foreach (IWebElement Price in CartProductPrices)
            {
                Prices.Add(Convert.ToDouble(Price.Text.Trim().Replace("$","")));
            }
            Prices.Sort();
            _webDriver.FindElement(By.XPath("//td[@class='product-price' and contains(.,'" + Prices[0] + "')]//preceding-sibling::td[@class='product-remove']//a")).Click();
            WaitUntil(()=> RemoveMessage.Text,result => result.Contains("removed"));
        }


        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });

        }
    }
}
