using SeleniumFramework.Drivers;
using SeleniumFramework.Utilities;
using SeleniumFramework.Pages;
using SeleniumFramework.Models;
using NUnit.Framework;
using System.Net;
namespace SeleniumFramework.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class LoginTests : BaseTests
    {
        [Test]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            var driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(ConfigReader.Get("baseUrl"));

            var loginPage = new LoginPage(driver);
            loginPage.OpenLoginPopup();
            loginPage.EnterUsername("anuroop");

            loginPage.EnterPassword("Password@123");
            loginPage.ClickSignIn();
        }
        [Test]
        public void Logout_WithValidCredentials_ShouldSucceed()
        {
            var driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(ConfigReader.Get("baseUrl"));

            var loginPage = new LoginPage(driver);
            loginPage.OpenLoginPopup()
            .EnterUsername("anuroop")
            .EnterPassword("Password@123")
            .ClickSignIn()

            .OpenLoginPopup()
            .ClickSignOut();
        }
        [TestCaseSource(typeof(TestDataReader), nameof(TestDataReader.GetLoginUserData))]

        public void Login_WithMultipleUserData(LoginData data)
        {
            var driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(ConfigReader.Get("baseUrl"));

            var loginPage = new LoginPage(driver);
            loginPage
            .OpenLoginPopup()
            .EnterUsername(data.username)
            .EnterPassword(data.password)
            .ClickSignIn()
            .OpenLoginPopup()
            .ClickSignOut();
        }
    }
}
