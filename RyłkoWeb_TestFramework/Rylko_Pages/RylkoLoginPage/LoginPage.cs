using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.Rylko_Pages.RylkoMainPage;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoLoginPage
{
    public class LoginPage
    {
        #region Methods
        public void NavigateToLoginPage()
        {
            TopPanel.NavigateToTopPanelLogoOption(MainPageTopPanelLogoOptions.Zaloguj);
        }

        public void LogIn(string email, string password, bool alertDisplays = false)
        {
            LoginUser.Login(email, password, alertDisplays);
        }

        public void RegisterUser(string email, bool checkAllCheckboxes, bool registrationSuccessful = true)
        {
            RegistrationUser.Register(email, checkAllCheckboxes, registrationSuccessful);
        }

        public void PasswordRecovery(string email, bool recoverySuccessful = true)
        {
            PasswordRecoveryPage.PasswordRecovery(email, recoverySuccessful);
        }
        #endregion

        #region Objects
        private TopPanelLogoSubPage TopPanel = new TopPanelLogoSubPage();
        private LoginSubPage LoginUser = new LoginSubPage();
        private RegistrationSubPage RegistrationUser = new RegistrationSubPage();
        private PasswordRecoverySubPage PasswordRecoveryPage = new PasswordRecoverySubPage();
        #endregion
    }
}
