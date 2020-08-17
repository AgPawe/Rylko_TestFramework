using RyłkoWeb_TestFramework.Rylko_Pages;
using RyłkoWeb_TestFramework.Rylko_Pages.RylkoLoginPage;
using RyłkoWeb_TestFramework.Rylko_Pages.RylkoMainPage;
using RyłkoWeb_TestFramework.Rylko_Pages.RylkoSearchPage;

namespace RyłkoWeb_TestFramework.TestInfrastructure
{
    public abstract class BaseXUnitTest : BaseXUnitContext
    {
        protected BaseXUnitTest()
        {
            RylkoMainPage = new MainPage();
            LoginPage = new LoginPage();
            SearchPage = new SearchPage();
        }
        protected MainPage RylkoMainPage;
        protected LoginPage LoginPage;
        protected SearchPage SearchPage;  
    }
}
