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
public class LockedOutUserSteps
{
    private readonly PlaywrightDriver _playwrightDriver;
    private readonly ScenarioContext _scenarioContext;

    public LockedOutUserSteps(PlaywrightDriver playwrightDriver, ScenarioContext scenarioContext)
    {
        _playwrightDriver = playwrightDriver;
        _scenarioContext = scenarioContext;
    }

    [Given("I am a locked out user on the Sauce Labs login page")]
    public async Task GivenIAmALockedOutUserOnTheSauceLabsLoginPage()
    {
        await _playwrightDriver.InitializeAsync();
        await _playwrightDriver.Page.GotoAsync("https://www.saucedemo.com/");
    }

    [When("I log in as a locked out user")]
    public async Task WhenILogInAsALockedOutUser()
    {
        await _playwrightDriver.Page.FillAsync("#user-name", "locked_out_user");
        await _playwrightDriver.Page.FillAsync("#password", "secret_sauce");
        await _playwrightDriver.Page.ClickAsync("#login-button");
    }

    [Then("I should see an error message indicating I am locked out")]
    public async Task ThenIShouldSeeAnErrorMessageIndicatingIAmLockedOut()
    {
        var errorMessage = await _playwrightDriver.Page.TextContentAsync("[data-test='error']");
        errorMessage.Should().Contain("Sorry, this user has been locked out.");
        await _playwrightDriver.DisposeAsync();
    }
}
