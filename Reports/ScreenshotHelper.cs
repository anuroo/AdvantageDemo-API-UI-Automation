using OpenQA.Selenium;
using System.IO;

public static class ScreenshotHelper
{
    public static string TakeScreenshot(IWebDriver driver, string testName)
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"{testName}_{timestamp}.png";
        string reportsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
        string screenshotDir = Path.Combine(reportsDir,"Screenshots");
        Directory.CreateDirectory(screenshotDir);
        string filePath = Path.Combine(screenshotDir, fileName);
        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(filePath);
        return Path.Combine("Screenshots", fileName);
    }
}