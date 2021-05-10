using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Acari.Services
{
    public class LinkedInAutomation
    {
        private readonly IWebDriver webDriver;

        public LinkedInAutomation(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Login(string username, string password)
        {
            // Navigate to LinkedIn
            webDriver.Url = "https://www.linkedin.com/";

            // Find the username field (Facebook calls it "email") and enter value
            var input = webDriver.FindElement(By.Id("session_key"));
            input.SendKeys(username);

            // Find the password field and enter value
            input = webDriver.FindElement(By.Id("session_password"));
            input.SendKeys(password);

            // Click on the login button
            ClickAndWaitForPageToLoad(webDriver, By.ClassName("sign-in-form__submit-button" +
                ""));

            // At this point, Facebook will launch a post-login "wizard" that will 
            // keep asking unknown amount of questions (it thinks it's the first time 
            // you logged in using this computer). We'll just click on the "continue" 
            // button until they give up and redirect us to our "wall".
            try
            {
                while (webDriver.FindElement(By.Id("checkpointSubmitButton")) != null)
                {
                    // Clicking "continue" until we're done
                    ClickAndWaitForPageToLoad(webDriver, By.Id("checkpointSubmitButton"));
                }
            }
            catch
            {
                // We will try to click on the next button until it's not there or we fail.
                // Facebook is unexpected as to what will happen, but this approach seems 
                // to be pretty reliable
            }
        }

        private void ClickAndWaitForPageToLoad(IWebDriver driver,
            By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                {
                    throw new NoSuchElementException(
                        "No elements " + elementLocator + " ClickAndWaitForPageToLoad");
                }
                var element = elements.FirstOrDefault(e => e.Displayed);
                try
                {
                    element.Click();
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine($"Count not click element <{elementLocator}>");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(
                    "Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
}