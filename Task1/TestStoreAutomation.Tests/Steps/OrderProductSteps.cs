using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace TestStoreAutomation.Tests.Steps
{
    [Binding]
    public class OrderProductSteps
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [Given(@"I am on the test store")]
        public void GivenIAmOnTheTestStore()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
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

        [When(@"I order the first in-stock non-promo product using South Africa as Country and Alberton as City")]
        public void WhenIOrderTheFirstInStockNonPromoProduct()
        {
            var products = _wait.Until(driver => driver.FindElements(By.CssSelector("div[data-testid='productCardContainer']")));

            IWebElement firstNonPromoProduct = null;
            foreach (var product in products)
            {
                var promoLabel = product.FindElements(By.XPath(".//p[text()='-50 %']"));
                if (promoLabel.Count == 0)
                {
                    firstNonPromoProduct = product;
                    break;
                }
            }

            Assert.NotNull(firstNonPromoProduct, "No non-promo product found.");

            firstNonPromoProduct.FindElement(By.TagName("a")).Click();

            var addToBasketButton = _wait.Until(driver => driver.FindElement(By.XPath("//button[contains(@class, '_2FTCz') and text()='Add to basket']")));
            addToBasketButton.Click();

            var checkoutButton = _wait.Until(driver => driver.FindElement(By.XPath("//button[@class='_2FTCz zlyBa nExvj ll85s R9U-8']")));
            checkoutButton.Click();

            var paymentButton = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='Go to payment']")));
            paymentButton.Click();

            var emailInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='email']")));
            emailInput.Click();
            emailInput.SendKeys("abc@gmail.com");

            var continueAsGuestButton = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='Continue as guest']")));
            continueAsGuestButton.Click();

            var firstNameInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='shippingAddress.firstName']")));
            firstNameInput.Click();
            firstNameInput.SendKeys("Javeria");

            var lastNameInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='shippingAddress.lastName']")));
            lastNameInput.Click();
            lastNameInput.SendKeys("Ijaz");

            var phoneInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='shippingAddress.phone']")));
            phoneInput.Click();
            phoneInput.SendKeys("102920111");

            var countryInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@class='Autocomplete_autocomplete__input__5yxYu Common_field___JumB']")));
            countryInput.Clear();
            countryInput.SendKeys("South");

            var countryOption = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='South Africa']")));
            countryOption.Click();

            var cityInput = _wait.Until(driver => driver.FindElements(By.XPath("//input[@class='Autocomplete_autocomplete__input__5yxYu Common_field___JumB']")));
            cityInput[1].Clear();
            cityInput[1].SendKeys("Alberton");

            var cityOption = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='Alberton']")));
            cityOption.Click();
           
            var postCodeInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='shippingAddress.postCode']")));
            postCodeInput.Click();
            postCodeInput.SendKeys("1029");

            var addressInput = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='shippingAddress.address']")));
            addressInput.Click();
            addressInput.SendKeys("Random Address");

            var map = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Map']")));

            var submitOrderButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//p[text()='Confirm order']")));
            submitOrderButton.Click();
        }

        [Then(@"the order should be placed successfully")]
        public void ThenTheOrderShouldBePlacedSuccessfully()
        {
            var confirmation = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='Your order has been placed successfully.']")));
            Assert.IsTrue(confirmation.Displayed);
            _driver.Quit();
        }
    }
}

