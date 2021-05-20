using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestProjectWithNunit.PageObjects;

namespace AmazonLandingPageOperations.Specs.PageObjects
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class AmazonLandingPage
    {
       
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;
        private readonly Actions action;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public AmazonLandingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            action = new Actions(_webDriver);
;
        }

        //Finding elements

        private IWebElement hoveroverSignInElement => _webDriver.FindElement(By.XPath("//div[@id='nav-tools']/a[2]"));

        private IWebElement signInBtn => _webDriver.FindElement(By.XPath("//div[@id='nav-flyout-ya-signin']/a/span"));
        
        public LoginPage HoverOverSignIn()
        {
            Actions act = action.MoveToElement(hoveroverSignInElement);
            act.Build().Perform();
            signInBtn.Click();
            return new LoginPage(_webDriver);
        }


       
        public void EnsureAmazonLandingPageIsOpenAndReset(String amazonHomePage)
        {
            if (_webDriver.Url != amazonHomePage)
            {
                _webDriver.Url = amazonHomePage;
            }
            //Otherwise reset the calculator by clicking the reset button
            
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