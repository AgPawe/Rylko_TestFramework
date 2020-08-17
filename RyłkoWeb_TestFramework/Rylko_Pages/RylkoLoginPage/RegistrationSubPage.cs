using OpenQA.Selenium;
using RyłkoWeb_TestFramework.TestInfrastructure;
using Shouldly;
using System.Collections.Generic;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoLoginPage
{
    internal class RegistrationSubPage : SeleniumExtensions
    {
        #region Methods
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

        private void RegistrationFailure()
        {
            registrationEmailInput.GetAttribute("class").ShouldContain("form-field__input--invalid");
            registrationFailureMessage.Text.ShouldBe(failureRegistrationMessageText);
        }
        #endregion

        #region Page elements
        private IWebElement registrationButton => Page.FindElement(By.CssSelector("a[href='/pl/access/registration_step1']"));
        private IWebElement registrationEmailInput => Page.FindElement(By.CssSelector("input[name = 'email']"));
        private IList<IWebElement> registrationCheckboxes => Page.FindElements(By.CssSelector(".form-field__checkbox label"));
        private IWebElement submitButton => Page.FindElement(By.CssSelector("button[type = 'submit']"));
        private IWebElement registrationFailureMessage => Page.FindElement(By.CssSelector("input[name = 'email'] +label +div"));
        private const string sucessfulRegistrationText = "Pomyślnie zarejestrowano konto użytkownika. Za kilka chwil otrzymasz mail z linkiem aktywacyjnym.";
        private const string failureRegistrationMessageText = "Klient o podanym adresie e-mail już istnieje.";
        #endregion
    }
}

