using NLog;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Browser;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        private WebDriverWait wait => new(Driver, TimeSpan.FromSeconds(15));
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        protected void ClickJS(By locator, int timeInSeconds, string elementName = null)
        {
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Clicking on element: {nameToLog}");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeInSeconds));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            js.ExecuteScript("arguments[0].click();", element);
        }
        protected void Click(By locator, string elementName = null)
        {
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Clicking on element: {nameToLog}");
            wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
        protected void Hover(By locator, string elementName = null)
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Hovering over element:{nameToLog}");
            new OpenQA.Selenium.Interactions.Actions(Driver)
                .MoveToElement(element)
                .Perform();
        }
        protected void EnterText(By locator, string text, string elementName = null)
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Entering {text} over element:{nameToLog}");
            element.Clear();
            element.SendKeys(text);
        }
        protected IWebElement WaitForElementVisible(By locator, string elementName = null)
        {
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Wait for element:{nameToLog} to be visible");
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementClickable(By locator, int timeInSeconds, string elementName = null)
        {
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Wait for element:{nameToLog} to be clickable in {timeInSeconds}s seconds");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        protected IWebElement WaitForElementTobeVisible(By locator, int timeInSeconds, string elementName = null)
        {
            try
            {
                string nameToLog = elementName ?? locator.ToString();
                Logger.Info($"Wait for element:{nameToLog} to be visible,for time: {timeInSeconds} seconds.");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeInSeconds));
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element with locator {locator} was not visible after {timeInSeconds}");
            }
        }
        protected string GetText(By locator, string elementName = null)
        {
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Retreiving text from element :{nameToLog}");
            return WaitForElementVisible(locator).Text;
        }
        protected void Sleep(int timeInSeconds)
        {
            Thread.Sleep(timeInSeconds * 1000);
        }
        protected void WaitForPageToLoad(int loadTime)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(loadTime));
            wait.Until(d =>
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");

            // Optional: wait for jQuery (if used)
            bool jqueryDefined = (bool)((IJavaScriptExecutor)Driver)
                .ExecuteScript("return typeof jQuery != 'undefined';");

            if (jqueryDefined)
            {
                wait.Until(d =>
                    (long)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active") == 0);
            }

            // Optional: if React specific loader
            wait.Until(d =>
                (bool)((IJavaScriptExecutor)d).ExecuteScript("return document.querySelectorAll('[data-loading]').length === 0"));
        }
        protected void SelectElementFromDropdown(By locator, string value, string elementName = null)
        {
            string nameToLog = elementName ?? locator.ToString();
            Logger.Info($"Selecting value: {value} from dropdown: {nameToLog}");
            var sleectElement = new SelectElement(WaitForElementTobeVisible(locator, 50));
            sleectElement.SelectByText(value);
        }

    }
}