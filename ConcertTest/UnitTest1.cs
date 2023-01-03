using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class SearchTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            //option.AddArgument("--headless");
            driver = new ChromeDriver(option);
            //driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void SearchCaseTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com.br/");
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("concert technologies");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            driver.Navigate().GoToUrl("https://www.google.com.br/search?q=concert+technologies&sxsrf=ALiCzsaC8moIvib1aOarGMERdw3XrTOpOg%3A1672770411576&source=hp&ei=a3O0Y6HVILue5OUPouO6sAQ&iflsig=AJiK0e8AAAAAY7SBexiiwuM2Pza-Cq9BRNoBKnfqMsGL&ved=0ahUKEwjhtq6xg6z8AhU7D7kGHaKxDkYQ4dUDCAg&uact=5&oq=concert+technologies&gs_lcp=Cgdnd3Mtd2l6EAMyBAgjECcyBAgAEEMyBAgAEEMyBAgAEEMyBQgAEIAEMgUIABCABDIFCAAQgAQyCAgAEIAEEMsBMggIABCABBDLATIICAAQgAQQywE6CwgAEIAEELEDEIMBOggILhCDARCxAzoFCC4QgAQ6EQguEIAEELEDEIMBEMcBENEDOgsILhCABBCxAxCDAToICAAQsQMQgwE6BggjECcQEzoOCAAQgAQQsQMQgwEQyQM6CAgAEIAEELEDOgoIABCABBCxAxAKOg0IABCABBCxAxCDARAKOgcIABCABBAKUABYv2RgynpoAHAAeACAAbgCiAGDGpIBCDAuMTUuNC4xmAEAoAEB&sclient=gws-wiz");

            String url = driver.Url;
            Assert.AreEqual(url, "https://www.google.com.br/search?q=concert+technologies&sxsrf=ALiCzsaC8moIvib1aOarGMERdw3XrTOpOg%3A1672770411576&source=hp&ei=a3O0Y6HVILue5OUPouO6sAQ&iflsig=AJiK0e8AAAAAY7SBexiiwuM2Pza-Cq9BRNoBKnfqMsGL&ved=0ahUKEwjhtq6xg6z8AhU7D7kGHaKxDkYQ4dUDCAg&uact=5&oq=concert+technologies&gs_lcp=Cgdnd3Mtd2l6EAMyBAgjECcyBAgAEEMyBAgAEEMyBAgAEEMyBQgAEIAEMgUIABCABDIFCAAQgAQyCAgAEIAEEMsBMggIABCABBDLATIICAAQgAQQywE6CwgAEIAEELEDEIMBOggILhCDARCxAzoFCC4QgAQ6EQguEIAEELEDEIMBEMcBENEDOgsILhCABBCxAxCDAToICAAQsQMQgwE6BggjECcQEzoOCAAQgAQQsQMQgwEQyQM6CAgAEIAEELEDOgoIABCABBCxAxAKOg0IABCABBCxAxCDARAKOgcIABCABBAKUABYv2RgynpoAHAAeACAAbgCiAGDGpIBCDAuMTUuNC4xmAEAoAEB&sclient=gws-wiz");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
