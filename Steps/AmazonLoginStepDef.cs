using AmazonLandingPageOperations.Specs.Drivers;
using AmazonLandingPageOperations.Specs.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestProjectWithNunit.PageObjects;

namespace AmazonLandingPageOperations.Specs.Steps
{
    [Binding]
    public sealed class AmazonLoginStepDef
    {
      
        private readonly AmazonLandingPage _amazonLandingPageObject;
        private LoginPage _loginpg;

        public AmazonLoginStepDef(BrowserDriver browserDriver)
        {
            _amazonLandingPageObject = new AmazonLandingPage(browserDriver.Current);

        }
        [Given(@"An user navigate to browser '(.*)'")]
        public void GivenAnUserNavigateToBrowser(string url)
        {
            _amazonLandingPageObject.EnsureAmazonLandingPageIsOpenAndReset(url);
        }

        [Given(@"hover over the SignInOption and click on the SignIn button")]
        public void GivenHoverOverTheSignInOptionAndClickOnTheSignInButton()
        {
            _loginpg=_amazonLandingPageObject.HoverOverSignIn();
        }


        [When(@"Clicked on the Continue without any data")]
        public void WhenClickedOnTheContinueWithoutAnyData()
        {
            _loginpg.Clearemail();
            _loginpg.ClickonContinieButton();
        }

        [Then(@"error message should show '(.*)'")]
        public void ThenErrorMessageShouldShow(string text)
        {

            var actualResult = _loginpg.geterrormessage();

            actualResult.Should().Be(text.ToString());
        }







    }
}