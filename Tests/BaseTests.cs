using SeleniumFramework.Drivers;
using AventStack.ExtentReports;
using SeleniumFramework.Reports;
using NLog;

namespace SeleniumFramework.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class BaseTests
    {
        protected ExtentReports extent;
        protected ExtentTest test;

        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void BeforeSetup()
        {
            extent = ExtentReportManager.GetInstance();
        }
        [SetUp]
        public void SetUp()
        {
            logger.Info("================== Starting Test =================");
            DriverFactory.InitDriver();
            string testname = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testname);
        }
        [TearDown]
        public void TearDown()
        {
            logger.Info("================== Ending Test =================");
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (testStatus == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = ScreenshotHelper.TakeScreenshot(DriverFactory.GetDriver(), TestContext.CurrentContext.Test.Name);
                test.Log(Status.Fail, "Test Failed.Screenshot attached");
                test.Fail($"Test Failed: {errorMessage}")
                    .AddScreenCaptureFromPath(screenshotPath);
            }
            else if (testStatus == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("Test Passed");
            }
            DriverFactory.QuitDriver();
        }
        [OneTimeTearDown]
        public void AfterTearDown()
        {
            extent.Flush();
        }
    }
}