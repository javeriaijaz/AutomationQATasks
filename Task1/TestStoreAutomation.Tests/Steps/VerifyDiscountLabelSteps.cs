using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace TestStoreAutomation.Tests.Steps
{
    [Binding]
    public class VerifyDiscountLabelSteps
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [Given(@"I am on the test store to verify discount label")]
        public void GivenIAmOnTheTestStoreToVerifyDiscountLabel()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://teststoreforsouthafri.nextbasket.shop/");
            _driver.Manage().Window.Maximize();

            try
            {
                var acceptCookiesButton = _wait.Until(driver => driver.FindElement(By.XPath("//button[text()='Accept all']")));
                acceptCookiesButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Handle the case where the cookies bar did not appear within the timeout period
            }
        }

        [Then(@"the ""50% off"" label should be visible")]
        public void ThenTheLabelShouldBeVisible()
        {
            var products = _wait.Until(driver => driver.FindElements(By.CssSelector("div[data-testid='productCardContainer']")));

            bool isLabelVisible = false;
            foreach (var product in products)
            {
                var promoLabel = product.FindElements(By.XPath("//p[text()='-50 %']"));
                if (promoLabel.Count > 0)
                {
                    isLabelVisible = true;
                    break;
                }
            }

            Assert.IsTrue(isLabelVisible, "The '50% off' label is not visible on any product.");
            _driver.Quit();
        }
    }
}
