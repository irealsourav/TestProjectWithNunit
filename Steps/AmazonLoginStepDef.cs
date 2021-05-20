using AmazonLandingPageOperations.Specs.Drivers;
using AmazonLandingPageOperations.Specs.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AmazonLandingPageOperations.Specs.Steps
{
    [Binding]
    public sealed class AmazonLoginStepDef
    {
      
        private readonly AmazonLandingPage _amazonLandingPageObject;

        public AmazonLoginStepDef(BrowserDriver browserDriver)
        {
            _amazonLandingPageObject = new AmazonLandingPage(browserDriver.Current);

        }
        [Given(@"An user navigate to browser '(.*)'")]
        public void GivenAnUserNavigateToBrowser(string url)
        {
            _amazonLandingPageObject.EnsureAmazonLandingPageIsOpenAndReset(url);
        }

        [Given(@"hoverover the SignInOption")]
        public void GivenHoveroverTheSignInOption()
        {
            _amazonLandingPageObject.HoverOverSignIn();
        }

        [Given(@"click on the SignIn button")]
        public void GivenClickOnTheSignInButton()
        {
            _amazonLandingPageObject.ClickSignInButton();
        }

        [When(@"Clicked on the Continue without any data")]
        public void WhenClickedOnTheContinueWithoutAnyData()
        {
            _amazonLandingPageObject.ClickonContinieButton();
        }

        [Then(@"error message should show '(.*)'")]
        public void ThenErrorMessageShouldShow(string text)
        {

            var actualResult = _amazonLandingPageObject.geterrormessage();

            actualResult.Should().Be(text.ToString());
        }







    }
}