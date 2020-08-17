using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure.Enums;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoMainPage
{
    public class MainPage
    {
        #region Methods
        public void SelectCurrency(Currency currency)
        {
            TopPanelLogo.SelectCurrency(currency);
        }

        public void SelectLanguage(Languages language)
        {
            TopPanelLogo.SelectLanguage(language);
        }

        public void NavigateToTopPanelLogoOption(MainPageTopPanelLogoOptions option)
        {
            TopPanelLogo.NavigateToTopPanelLogoOption(option);
        }

        public void NavigateToTopPanelShoppingOption(MainPageTopPanelShoppingOption option)
        {
            TopPanelShopping.NavigateToTopPanelShoppingOption(option);
        }
        #endregion

        #region Objects
        private TopPanelLogoSubPage TopPanelLogo = new TopPanelLogoSubPage();
        private TopPanelShoppingSubPage TopPanelShopping = new TopPanelShoppingSubPage();
        #endregion
    }
}

