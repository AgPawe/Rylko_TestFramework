using OpenQA.Selenium;
using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure;
using RyłkoWeb_TestFramework.Rylko_Pages.Rylko_MainPage;
using System.Collections.Generic;
using Shouldly;

namespace RyłkoWeb_TestFramework.Rylko_Pages.Rylko_SearchPage
{
    public class SearchPage : SeleniumExtensions
    {
        public void SearchProduct(string product, bool available = true)
        {
            TopPanel.GoToRightSideIconsOption(MainPageTopPanelIconsOptions.Search);
            WaitForElementIsDisplayed(searchInput);
            searchInput.SendKeys(product);
            ClickElement(searchButton);
            listedProducts.ShouldNotBeNull();

            if (available)
                listedProducts.ShouldNotBeNull();
            else
                noResultMessage.Text.ShouldBe(noResultMessageText);
        }

        public void ClearSearch()
        {
            ClickElement(clearButton);
        }


        #region Objects
        private IWebElement searchInput => Page.FindElement(By.CssSelector("li.nav-item.mr-3.d-none.d-lg-inline-block > div > div > div > div > input"));
        private IWebElement searchButton => Page.FindElement(By.CssSelector("li.nav-item.mr-3.d-none.d-lg-inline-block div.form-field__append > button i[class='i-loupe']"));
        private IWebElement clearButton => Page.FindElement(By.CssSelector("#twig-container i[class='i-close']"));
        private IList<IWebElement> listedProducts => Page.FindElements(By.ClassName("VueCarousel"));
        private IWebElement noResultMessage => Page.FindElement(By.CssSelector(".text-center.text-uppercase"));
        #endregion

        public SearchPage()
        {
            TopPanel = new RylkoTopPanelSubPage();
        }

        private RylkoTopPanelSubPage TopPanel { get; }
        private const string noResultMessageText = "NIESTETY NIE ZNALEŹLIŚMY TEGO, CZEGO SZUKASZ. SPRÓBUJ WYBRAĆ MNIEJ PARAMETRÓW BĄDŹ SPRAWDŹ W INNEJ KATEGORII.";
    }
}
