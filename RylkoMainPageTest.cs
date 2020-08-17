using RyłkoWeb_TestFramework.Rylko_Pages;
using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure;
using RyłkoWeb_TestFramework.TestInfrastructure.Enums;
using Xunit;

namespace RyłkoWeb_TestFramework.Rylko_Tests
{
    public class MainPage : BaseXUnitTest
    {
        [Fact]
        public void RylkoMainPageTest()
        {
            RylkoMainPage.GoToCategory(TopPanelCategories.Bags);
            RylkoMainPage.SelectLanguage(Languages.Russian);
            RylkoMainPage.SelectLanguage(Languages.Polish);
            RylkoMainPage.NavigateToLeftCornerOption(MainPageTopPanelOptions.ZnajdzNas);
            LoginPage.NavigateToLoginPage();

        }
    }
}
