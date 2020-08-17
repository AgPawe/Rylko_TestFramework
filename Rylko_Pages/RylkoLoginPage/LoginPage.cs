using OpenQA.Selenium;

namespace RyłkoWeb_TestFramework.Rylko_Pages.Rylko_MainPage
{
    public class LoginPage
    {
        
        public void NavigateToLoginPage()
        {
            TopPanel.NavigateToLoginPage();
        }

        public void LogIn(string email, string password, bool alertDisplays = false)
        {
            LoginUserPage.Login(email, password, alertDisplays);
        }

        public void RegisterUser(string email, bool checkAllCheckboxes, bool registrationSuccessful = true)
        {
            LoginUserPage.Register(email, checkAllCheckboxes, registrationSuccessful);
        }

        public void PasswordRecovery(string email, bool recoverySuccessful = true)
        {
            LoginUserPage.PasswordRecovery(email, recoverySuccessful);
        }

        public LoginPage()
        {
            TopPanel = new RylkoTopPanelSubPage();
            LoginUserPage = new LoginSubPage();

        }

        private RylkoTopPanelSubPage TopPanel { get; }
        private LoginSubPage LoginUserPage { get; }
    }
}
