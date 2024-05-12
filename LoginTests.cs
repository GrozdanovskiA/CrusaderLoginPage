using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LoginPageTest
{
    public class LoginTests : IDisposable
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        public LoginTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://crusader.bransys.com/");

            _loginPage = new LoginPage(_driver);
        }

        [Fact]
        public void LoginFieldsAreDisplayed()
        {
            Assert.True(_loginPage.IsUserNameFieldDisplayed());
            Assert.True(_loginPage.IsPasswordFieldDisplayed());
        }

        [Fact]
        public void InputDataValidation() 
        {
            var userName = "User" + Guid.NewGuid();
            var pass = "Pass" + Guid.NewGuid();

            _loginPage.EnterUsername(userName);
            _loginPage.EnterPassword(pass);

            Assert.Equal(userName, _loginPage.GetUsernameValue());
            Assert.Equal(pass, _loginPage.GetPasswordValue());
        }

        [Fact]
        public void ErrorMessageText()
        {
            var userName = "User" + Guid.NewGuid();
            var pass = "Pass" + Guid.NewGuid();

            _loginPage.EnterUsername(userName);
            _loginPage.EnterPassword(pass);
            _loginPage.ClickSignButton();
            
            Thread.Sleep(500);
            
            Assert.Equal("Incorrect email/username or password", _loginPage.GetErrorMessageText());
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}