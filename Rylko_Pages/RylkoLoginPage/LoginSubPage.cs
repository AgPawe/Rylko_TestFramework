using OpenQA.Selenium;
using RyłkoWeb_TestFramework.TestInfrastructure;
using System.Collections.Generic;
using Shouldly;

namespace RyłkoWeb_TestFramework.Rylko_Pages.Rylko_MainPage
{
    public class LoginSubPage : SeleniumExtensions
    {
        internal void Login(string email, string password, bool loginSuccessful = true)
        {
   
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            ClickElement(loginButton);

            if (loginSuccessful == false)
                VerifyAlertText(errorAlertText);

        }

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

        internal void Register(string email, bool checkAllCheckboxes, bool registrationSuccessful = true)
        {
            ClickElement(registrationButton);
            registrationEmailInput.SendKeys(email);

            if (checkAllCheckboxes)
                foreach (var checkbox in registrationCheckboxes)
                {
                    if (checkbox.GetAttribute("class").Equals("form__checkbox-label "))
                        checkbox.Click();
                    checkbox.Selected.Equals(true);
                }
            else
                foreach (var checkbox in registrationCheckboxes)
                {
                    var required = checkbox.GetAttribute("for");
                    if (required.Equals("consent_regulations"))
                    {
                        checkbox.Click();
                        checkbox.Selected.Equals(true);
                    }      
                }


            ClickElement(submitButton);

            if (registrationSuccessful)
                VerifyAlertMessage(sucessfulRegistrationText);
            else
                RegistrationFailure();
        }

        private void VerifyAlertMessage(string alertText)
        {
            WaitForElementIsDisplayed(successAlert);
            successAlert.Text.ShouldBe(alertText.ToUpper());
            successAlertCloseButton.Click();
        }

        private void RegistrationFailure()
        {
            registrationEmailInput.GetAttribute("class").ShouldContain("form-field__input--invalid");
            registrationFailureMessage.Text.ShouldBe(failureRegistrationMessageText);
        }

        #region Objects

        private IWebElement emailInput => Page.FindElement(By.Id("InputEmail"));
        private IWebElement passwordInput => Page.FindElement(By.Id("InputPsw"));
        private IWebElement loginButton => Page.FindElement(By.ClassName("btn btn-primary mb-3 w-100"));
        private IWebElement passForgottenButton => Page.FindElement(By.CssSelector("a[href ='/pl/access/resetPassword_step1']"));
        private IWebElement passwordRecoveryEmailInput => Page.FindElement(By.CssSelector("input[name = 'login']"));
        private IWebElement submitButton => Page.FindElement(By.CssSelector("button[type = 'submit']"));
        private IWebElement registrationButton => Page.FindElement(By.CssSelector("a[href='/pl/access/registration_step1']"));
        private IWebElement registrationEmailInput => Page.FindElement(By.CssSelector("input[name = 'email']"));
        private IList<IWebElement> registrationCheckboxes => Page.FindElements(By.CssSelector(".form-field__checkbox label"));
        private IWebElement successAlert => Page.FindElement(By.CssSelector(".container div[role='alert'] span"));
        private IWebElement successAlertCloseButton => Page.FindElement(By.CssSelector(".container div[role='alert'] button[class='close']"));
        private IWebElement registrationFailureMessage => Page.FindElement(By.CssSelector("input[name = 'email'] +label +div"));

        private const string errorAlertText = "Podano nieprawidłowe dane do logowania. Spróbuj ponownie.";
        private const string sucessfulRegistrationText = "Pomyślnie zarejestrowano konto użytkownika. Za kilka chwil otrzymasz mail z linkiem aktywacyjnym.";
        private const string failureRegistrationMessageText = "Klient o podanym adresie e-mail już istnieje.";
        private const string sucessfulPasswordRecoveryText = "Za kilka chwil otrzymasz email zawierający link do zmiany hasła.";
        private const string failurePasswordRecoveryText = "Wystąpił błąd podczas resetowania hasła.";
        #endregion
    }
}
