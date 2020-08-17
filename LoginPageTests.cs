using RyłkoWeb_TestFramework.TestInfrastructure;
using Xunit;

namespace Tests.RylkoTests.LoginTests
{
    public class RegistrationTest : BaseXUnitTest
    {
        [Fact]
        public void SuccessfulRegistrationUserTest()
        {
            LoginPage.NavigateToLoginPage();
            LoginPage.RegisterUser(unregisteredEmail, checkAllCheckboxes: false, registrationSuccessful: true);
        }

        [Fact]
        public void RegistrationfailureTest()
        {
            LoginPage.NavigateToLoginPage();
            LoginPage.RegisterUser(registeredEmail, checkAllCheckboxes: false, registrationSuccessful: false);
        }

        [Fact]
        public void PasswordRecoveryTest()
        {
            LoginPage.NavigateToLoginPage();
            LoginPage.PasswordRecovery(registeredEmail);
        }

        private const string registeredEmail = "agato.pawelczak @gmail.com";
        private const string unregisteredEmail = "rylkotest@gmail.com";
    }
}
