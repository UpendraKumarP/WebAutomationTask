Feature: Shopping Cart

Scenario: ValidCase_Verify if Shopping Cart working fine for adding and removing items
Given I am at Ecommerce shop
When I add 4 random items to my cart
And I open the cart
Then I should see 4 items listed in my cart
When I search for lowest price item and removed it from my cart
Then I should see 3 items listed in my cart

Scenario: InvalidCase1_Verify if Shopping Cart failing if cart items are not matching with added items 
Given I am at Ecommerce shop
When I add 4 random items to my cart
And I open the cart
#Providing wrong expected count after items added in cart
Then I should see 3 items listed in my cart
When I search for lowest price item and removed it from my cart
Then I should see 3 items listed in my cart

Scenario: InvalidCase2_Verify if Shopping Cart failing if cart items are not matching with remaining items after item removed 
Given I am at Ecommerce shop
When I add 4 random items to my cart
And I open the cart
Then I should see 4 items listed in my cart
When I search for lowest price item and removed it from my cart
#Providing wrong expected count after item removed from cart
Then I should see 4 items listed in my cart