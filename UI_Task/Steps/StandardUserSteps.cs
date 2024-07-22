using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using UI_Task.Drivers;
using FluentAssertions;

namespace UI_Task.Steps;

[Binding]
public class StandardUserSteps
{
    private readonly PlaywrightDriver _playwrightDriver;
    private readonly ScenarioContext _scenarioContext;

    public StandardUserSteps(PlaywrightDriver playwrightDriver, ScenarioContext scenarioContext)
    {
        _playwrightDriver = playwrightDriver;
        _scenarioContext = scenarioContext;
    }

    [Given("I am a standard user on the Sauce Labs login page")]
    public async Task GivenIAmAStandardUserOnTheSauceLabsLoginPage()
    {
        await _playwrightDriver.InitializeAsync();
        await _playwrightDriver.Page.GotoAsync("https://www.saucedemo.com/");
    }

    [When("I log in as a standard user")]
    public async Task WhenILogInAsAStandardUser()
    {
        await _playwrightDriver.Page.FillAsync("#user-name", "standard_user");
        await _playwrightDriver.Page.FillAsync("#password", "secret_sauce");
        await _playwrightDriver.Page.ClickAsync("#login-button");
    }

    [When("I add an item to the cart")]
    public async Task WhenIAddAnItemToTheCart()
    {
        await _playwrightDriver.Page.ClickAsync("text=Add to cart");
    }

    [When("I proceed to checkout")]
    public async Task WhenIProceedToCheckout()
    {
        await _playwrightDriver.Page.ClickAsync(".shopping_cart_link");
        await _playwrightDriver.Page.ClickAsync("#checkout");
    }

    [When("I enter my shipping information")]
    public async Task WhenIEnterMyShippingInformation()
    {
        await _playwrightDriver.Page.FillAsync("#first-name", "John");
        await _playwrightDriver.Page.FillAsync("#last-name", "Doe");
        await _playwrightDriver.Page.FillAsync("#postal-code", "12345");
        await _playwrightDriver.Page.ClickAsync("#continue");
    }

    [When("I complete the purchase")]
    public async Task WhenICompleteThePurchase()
    {
        await _playwrightDriver.Page.ClickAsync("#finish");
    }

    [Then("I should see a confirmation message that my order was placed")]
    public async Task ThenIShouldSeeAConfirmationMessageThatMyOrderWasPlaced()
    {
        var confirmationMessage = await _playwrightDriver.Page.TextContentAsync(".complete-header");
        confirmationMessage.Should().Be("Thank you for your order!");
        await _playwrightDriver.DisposeAsync();
    }
}
