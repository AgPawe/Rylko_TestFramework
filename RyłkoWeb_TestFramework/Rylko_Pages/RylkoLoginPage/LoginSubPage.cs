using OpenQA.Selenium;
using RyłkoWeb_TestFramework.TestInfrastructure;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoLoginPage
{
    internal class LoginSubPage : SeleniumExtensions
    {
        #region Methods
        internal void Login(string email, string password, bool loginSuccessful = true)
        {
   
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            ClickElement(loginButton);

            if (loginSuccessful == false)
                VerifyAlertText(errorAlertText);

        }
        #endregion

        #region Page elements
        private IWebElement emailInput => Page.FindElement(By.Id("InputEmail"));
        private IWebElement passwordInput => Page.FindElement(By.Id("InputPsw"));
        private IWebElement loginButton => Page.FindElement(By.ClassName("btn btn-primary mb-3 w-100"));
        private const string errorAlertText = "Podano nieprawidłowe dane do logowania. Spróbuj ponownie.";
       #endregion
    }
}
