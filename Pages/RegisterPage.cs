using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class RegisterPage : BasePage
    {
        protected readonly By inputFirstName = By.CssSelector("input[name='usernameRegisterPage']");
        protected readonly By inputMailName = By.CssSelector("input[name='emailRegisterPage']");
        protected readonly By passwordField = By.CssSelector("input[name='passwordRegisterPage']");
        protected readonly By confirmPasswordField = By.CssSelector("input[name='confirm_passwordRegisterPage']");
        protected readonly By selectCountry = By.CssSelector("select[name='countryListboxRegisterPage']");
        protected readonly By firstNameField = By.XPath("//input[@name='first_nameRegisterPage']");
        protected readonly By phoneNumberField = By.XPath("//input[@name='phone_numberRegisterPage']");
        protected readonly By cityField = By.XPath("//input[@name='cityRegisterPage']");
        protected readonly By addressField = By.XPath("//input[@name='addressRegisterPage']");
        protected readonly By stateField = By.XPath("//input[@name='state_/_province_/_regionRegisterPage']");
        protected readonly By postalCode = By.XPath("//input[@name='postal_codeRegisterPage']");
        protected readonly By registerButton = By.XPath("//button[@id='register_btn']");
        protected readonly By agreeTerms = By.XPath("//input[@name='i_agree']");

        public RegisterPage(IWebDriver driver) : base(driver) { }


        public RegisterPage EnterUserName(string firstName)
        {
            EnterText(inputFirstName, firstName, "First Name field");
            return this;
        }
        public RegisterPage EnterEmail(string email)
        {
            EnterText(inputMailName, email, "Eamil field");
            return this;
        }
        public RegisterPage EnterPassword(string password)
        {
            EnterText(passwordField, password, "password field");
            return this;
        }
        public RegisterPage EnterConfirmedPassword(string confirmPassword)
        {
            EnterText(confirmPasswordField, confirmPassword, "Confirm password field");
            return this;
        }
        public RegisterPage SelectCountry(string country)
        {
            SelectElementFromDropdown(selectCountry, country, "Country dropdown");
            return this;
        }
        public RegisterPage EnterFirstName(string firstName)
        {
            EnterText(firstNameField, firstName, "firstname field");
            return this;
        }
        public RegisterPage EnterPhoneNumber(string phoneNumber)
        {
            EnterText(phoneNumberField, phoneNumber, "phonenumber field");
            return this;
        }
        public RegisterPage EnterCityField(string city)
        {
            EnterText(cityField, city, "city field");
            return this;
        }
        public RegisterPage EnterAddressField(string address)
        {
            EnterText(addressField, address, "address field");
            return this;
        }
        public RegisterPage EnterStateField(string state)
        {
            WaitForElementTobeVisible(stateField, 50);
            EnterText(stateField, state, "state field");
            return this;
        }
        public RegisterPage EnterPostalCodeField(string code)
        {
            WaitForElementTobeVisible(postalCode, 50);
            EnterText(postalCode, code, "code field");
            return this;
        }
        public RegisterPage ClickRegisterButton()
        {
            WaitForElementClickable(registerButton, 50, "Register button");
            ClickJS(registerButton, 50);
            return this;
        }
        public RegisterPage ClickAgreeTermAndConditions()
        {
            WaitForElementClickable(agreeTerms, 50, "agree terms button");
            ClickJS(agreeTerms, 50);
            return this;
        }
    }
}