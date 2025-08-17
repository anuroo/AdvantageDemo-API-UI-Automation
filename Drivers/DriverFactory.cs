using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using SeleniumFramework.Utilities;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework.Drivers
{
    public static class DriverFactory
    {
        private static ThreadLocal<IWebDriver> driver = new();
        public static IWebDriver GetDriver() => driver.Value;

        public static void InitDriver()
        {
            string browser = ConfigReader.Get("browser")?.ToLower();
            string executionEnv = ConfigReader.Get("executionEnv").ToLower();
            string gridUrl = ConfigReader.Get("gridUrl");
            if (executionEnv == "local")
            {
                driver.Value = browser switch
                {
                    "chrome" => new ChromeDriver(),
                    "firefox" => new FirefoxDriver(),
                    "edge" => new EdgeDriver(),
                    _ => new ChromeDriver()
                };
            }
            else if (executionEnv == "remote")
            {
                var capabilities = new OpenQA.Selenium.Chrome.ChromeOptions();
                capabilities.AddArgument("--start-maximized");

                driver.Value = new RemoteWebDriver(new Uri(gridUrl), capabilities.ToCapabilities(), TimeSpan.FromSeconds(60));
            }
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}