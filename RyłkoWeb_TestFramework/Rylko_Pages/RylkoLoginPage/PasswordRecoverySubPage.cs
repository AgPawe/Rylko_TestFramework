using OpenQA.Selenium;
using RyłkoWeb_TestFramework.TestInfrastructure;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoLoginPage
{
    internal class PasswordRecoverySubPage : SeleniumExtensions
    {
        #region Methods
        internal void PasswordRecovery(string email, bool recoverySuccessful)
        {
            ClickElement(passForgottenButton);
            passwordRecoveryEmailInput.SendKeys(email);
            ClickElement(submitButton);

            if (recoverySuccessful)
                VerifyAlertMessage(sucessfulPasswordRecoveryText);
            else
                VerifyAlertMessage(failurePasswordRecoveryText);
        }
        #endregion

        #region Page elements
        private IWebElement submitButton => Page.FindElement(By.CssSelector("button[type = 'submit']"));
        private IWebElement passForgottenButton => Page.FindElement(By.CssSelector("a[href ='/pl/access/resetPassword_step1']"));
        private IWebElement passwordRecoveryEmailInput => Page.FindElement(By.CssSelector("input[name = 'login']"));
        private const string sucessfulPasswordRecoveryText = "Za kilka chwil otrzymasz email zawierający link do zmiany hasła.";
        private const string failurePasswordRecoveryText = "Wystąpił błąd podczas resetowania hasła.";
        #endregion
    }
}
