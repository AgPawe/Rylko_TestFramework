using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure;
using RyłkoWeb_TestFramework.TestInfrastructure.Enums;
using Xunit;

namespace RyłkoWeb_TestFramework.Rylko_Tests
{
    public partial class MainPage : BaseXUnitTest
    {
        [Fact]
        public void RylkoMainPageTest()
        {
            RylkoMainPage.NavigateToTopPanelShoppingOption(MainPageTopPanelShoppingOption.Bags);
            RylkoMainPage.SelectLanguage(Languages.Russian);
            RylkoMainPage.SelectLanguage(Languages.Polish);
            RylkoMainPage.NavigateToTopPanelLogoOption(MainPageTopPanelLogoOptions.ZnajdzNasLink);
            LoginPage.NavigateToLoginPage();

        }
    }
}
