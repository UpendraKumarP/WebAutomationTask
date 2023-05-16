using System;
using WebAutomationTask.Drivers;
using TechTalk.SpecFlow;
using WebAutomationTask.PageObjects;

namespace WebAutomationTask.StepDefinitions
{
    [Binding]
    public sealed class ShoppingCartStepDefinitions
    {
        private readonly ShoppingCartPageObject _shoppingCartPageObject;

        public ShoppingCartStepDefinitions(BrowserDriver browserDriver)
        {
            _shoppingCartPageObject = new ShoppingCartPageObject(browserDriver.Current);
        }

        [Given(@"I am at Ecommerce shop")]
        public void GivenIAmAtEcommerceShop()
        {
            _shoppingCartPageObject.OpenPage();
        }

        [When(@"I add (.*) random items to my cart")]
        public void WhenIAddRandomItemsToMyCart(int NumberOfItems)
        {
            _shoppingCartPageObject.AddItemsToTheCart(NumberOfItems);
        }

        [When(@"I open the cart")]
        public void WhenIOpenTheCart()
        {
            _shoppingCartPageObject.OpenTheCart();
        }


        [When(@"I search for lowest price item and removed it from my cart")]
        public void WhenISearchForLowestPriceItemAndRemovedItFromMyCart()
        {
            _shoppingCartPageObject.removeLowestPricedItem();
        }

        [Then(@"I should see (.*) items listed in my cart")]
        public void ThenIShouldSeeItemsListedInMyCart(int NumberOfItems)
        {
            Assert.Equal(NumberOfItems, _shoppingCartPageObject.TotalQuantityInTheCart());
        }
    }
}
