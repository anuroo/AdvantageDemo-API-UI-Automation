using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace SeleniumFramework.Reports
{
    public class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentSparkReporter _htmlReporter;

        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Results", $"Extent_Report_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                _htmlReporter = new ExtentSparkReporter(reportPath);
                _htmlReporter.Config.DocumentTitle = "Selenium Automation Test Report";
                _htmlReporter.Config.ReportName = "UI Framework Tests";
                _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(_htmlReporter);
            }
            return _extent;
        }
    }
}