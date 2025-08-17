using SeleniumFramework.Drivers;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;
namespace SeleniumFramework.Tests
{
    public class RegisterTests : BaseTests
    {
        [TestCaseSource(typeof(TestDataReader), nameof(TestDataReader.GetRegisterUserData))]
        public void Register_WithVaildDetails(RegisterUserdata data)
        {
            var driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(ConfigReader.Get("baseUrl"));

            var LoginPage = new LoginPage(driver);
            LoginPage.OpenLoginPopup();
            RegisterPage registerpage = LoginPage.ClickRegister();

            registerpage
            .EnterUserName(data.username)
            .EnterEmail(data.email)
            .EnterPassword(data.password)
            .EnterConfirmedPassword(data.confirmPassword)
            .EnterFirstName(data.firstName)
            .EnterPhoneNumber(data.phoneNumber)
            .SelectCountry(data.country)
            .EnterCityField(data.city)
            .EnterAddressField(data.address)
            .EnterPostalCodeField(data.postalCode)
            .ClickAgreeTermAndConditions()
            .ClickRegisterButton();
            
        }
    }
}