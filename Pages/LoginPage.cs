using OpenQA.Selenium;
namespace SeleniumFramework.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By menuLoginIcon = By.Id("menuUserLink");
        private readonly By usernameField = By.XPath("//input[@name='username']");
        private readonly By passwordField = By.XPath("//input[@name='password']");
        private readonly By signInButton = By.XPath("//button[@id='sign_in_btn']");
        private readonly By signOutButton = By.XPath("//div[@id='loginMiniTitle']/label[text()='Sign out']");
        private readonly By createNewAccountLink = By.XPath("//a[text()='CREATE NEW ACCOUNT']");
        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage OpenLoginPopup()
        {
            WaitForPageToLoad(50);
            WaitForElementClickable(menuLoginIcon, 30);
            ClickJS(menuLoginIcon, 30);
            return this;
        }
        public LoginPage EnterUsername(string username)
        {
            EnterText(usernameField, username);
            return this;
        }
        public LoginPage EnterPassword(string password)
        {
            EnterText(passwordField, password);
            WaitForPageToLoad(10);
            return this;
        }
        public LoginPage ClickSignIn()
        {
            Sleep(2);
            WaitForElementClickable(signInButton, 50);
            ClickJS(signInButton, 30);
            return this;
        }
        public LoginPage ClickSignOut()
        {
            WaitForElementClickable(signOutButton, 50);
            ClickJS(signOutButton, 30);
            return this;
        }
        public RegisterPage ClickRegister()
        {
            WaitForElementClickable(createNewAccountLink, 30);
            ClickJS(createNewAccountLink, 30);
            return new RegisterPage(Driver);
        }
        
    }
}