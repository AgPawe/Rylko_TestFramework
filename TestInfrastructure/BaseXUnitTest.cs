using RyłkoWeb_TestFramework.Rylko_Pages;
using RyłkoWeb_TestFramework.Rylko_Pages.Rylko_MainPage;
using RyłkoWeb_TestFramework.Rylko_Pages.Rylko_SearchPage;

namespace RyłkoWeb_TestFramework.TestInfrastructure
{
    public abstract class BaseXUnitTest : BaseXUnitContext
    {
        protected BaseXUnitTest()
        {
            RylkoMainPage = new RylkoMainPage();
            LoginPage = new LoginPage();
            SearchPage = new SearchPage();
        }
        protected RylkoMainPage RylkoMainPage;
        protected LoginPage LoginPage;
        protected SearchPage SearchPage;
        
    }
}
