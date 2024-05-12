using OpenQA.Selenium;

namespace LoginPageTest
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        //Username field selector by attribute id
        By _userNameSelector = By.Id("input-204");

        //Username web element for manipulation
        private IWebElement _userNameField;

        By _passwordSelector = By.Id("input-207");

        private IWebElement _passwordField;

        By _signInButtonSelector = By.XPath("//*[@id=\"app\"]/div/div/div/div/div/div/div/div/div[2]/div[2]/form/div[2]/div[1]/button");
        
        private IWebElement _signInButton;

        By _errorMsgSelector = By.XPath("//*[@id=\"app\"]/div/div/div/div/div/div/div/div/div[2]/div[2]/form/div[1]/div[3]");
        

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;

            _userNameField = driver.FindElement(_userNameSelector);
            _passwordField = driver.FindElement(_passwordSelector);
            _signInButton = driver.FindElement(_signInButtonSelector);            
        }

        public bool IsUserNameFieldDisplayed()
        {
            return _userNameField.Displayed;
        }

        public bool IsPasswordFieldDisplayed()
        {
            return _passwordField.Displayed;
        }

        public void EnterUsername(string username)
        {
            _userNameField.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            _passwordField.SendKeys(password);
        }

        public string GetUsernameValue()
        {
            return _userNameField.GetAttribute("value");
        }
        public string GetPasswordValue() 
        {
            return _passwordField.GetAttribute("value");
        }

        public void ClickSignButton()
        {
            _signInButton.Click();
        }

        public string GetErrorMessageText()
        {
            return _driver.FindElement(_errorMsgSelector).Text;
        }
       


    }
}
