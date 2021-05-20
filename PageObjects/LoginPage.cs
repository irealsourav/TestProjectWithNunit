using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectWithNunit.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions action;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            action = new Actions(_webDriver);
            ;
        }
        private IWebElement email => _webDriver.FindElement(By.Name("email"));
        private IWebElement continueButton => _webDriver.FindElement(By.Id("continue"));

        private IWebElement errormessage => _webDriver.FindElement(By.XPath("//div[contains(text(),'Enter your email or mobile phone number')]"));




        public void Clearemail() => email.Clear();

        public void ClickonContinieButton() => continueButton.Click();


        public String geterrormessage()
        {
            return errormessage.Text;
        }
    }
}
