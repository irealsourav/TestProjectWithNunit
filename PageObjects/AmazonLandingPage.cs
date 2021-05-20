using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AmazonLandingPageOperations.Specs.PageObjects
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class AmazonLandingPage
    {
       
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;
        private readonly Actions builder;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public AmazonLandingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            builder = new Actions(_webDriver);
;
        }

        //Finding elements

        private IWebElement hoveroverSignInElement => _webDriver.FindElement(By.Id("nav-link-accountList"));

        private IWebElement signInBtn => _webDriver.FindElement(By.XPath("//div[@id='nav-flyout-ya-signin']/a/span"));
        private IWebElement email => _webDriver.FindElement(By.Name("email"));
        private IWebElement continueButton => _webDriver.FindElement(By.Id("continue"));

        private IWebElement errormessage => _webDriver.FindElement(By.XPath("//div[contains(text(),'Enter your email or mobile phone number')]"));



        public void HoverOverSignIn()
        {
            Actions act=builder.MoveToElement(hoveroverSignInElement);
            act.Build().Perform();
            act.MoveToElement(signInBtn).Build().Perform();

           
        }

        public void ClickSignInButton() => signInBtn.Click();


        public void Clearemail() => email.Clear();

        public void ClickonContinieButton() => continueButton.Click();

        public void EnsureAmazonLandingPageIsOpenAndReset(String amazonHomePage)
        {
            if (_webDriver.Url != amazonHomePage)
            {
                _webDriver.Url = amazonHomePage;
            }
            //Otherwise reset the calculator by clicking the reset button
            
        }
       
        public String geterrormessage()
        {
            return errormessage.Text;
        }
        public string WaitForNonEmptyResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () =>
                {
                    return errormessage.GetAttribute("value");
                },
                result => !string.IsNullOrEmpty(result));
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
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