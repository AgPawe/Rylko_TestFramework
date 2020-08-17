using OpenQA.Selenium;
using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure;
using Shouldly;
using System.Collections.Generic;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoMainPage
{
    internal class TopPanelLogoSubPage : SeleniumExtensions
    {
        #region Methods
        internal void NavigateToTopPanelLogoOption(MainPageTopPanelLogoOptions option)
        {
            if (option.ToString().Contains("Icon"))
            {
                ClickElement(rightMenuOptionsIcons(option.GetDescription()));
            }
            else if(option.ToString().Contains("Link"))
            {
                ClickElement(TopMenuList(option.GetDescription()));
            }
            else
            {
                ClickElement(TopMenuList(option.GetDescription(), 2));
            }
            
        }
        
        internal void SelectLanguage(Languages language)
        {
            const string url = "https://www.rylko.com/";
            languageBox.Click();
            WaitForElementIsDisplayed(languagesList[1]);
            foreach (IWebElement languageSelect in languagesList)
            {
                if (languageSelect.Text.Equals(language.GetDescription()))
                {
                    ClickElement(languageSelect);
                    break;
                }
            }
            
             WaitForPageLoaded($"{url}{language.GetDescription()}");

            languageBox.Text.ShouldBe(language.GetDescription());
        }

        internal void SelectCurrency(Currency currency)
        {
            currencyBox.Click();
            WaitForElementIsDisplayed(currencyList[1]);

            foreach (IWebElement currencySelect in currencyList)
            {
                if (currencySelect.Text.Equals(currency.GetDescription()))
                {
                    ClickElement(currencySelect);
                    break;
                }
            }
            
            currencyBox.Text.ShouldBe(currency.GetDescription());
        }
        #endregion

        #region Page elements
        private IWebElement optionFromLeftMenu(string option) 
            => Page.FindElement(By.XPath($"//p[contains(@class, 'd-inline text-uppercase')]/a[contains(text(), '{option}')]"));

        private IWebElement languageBox => Page.FindElement(By.CssSelector("span[class$='select-box--lang mr-2'] li[class ='list-select--head']"));
        private IList<IWebElement> languagesList => Page.FindElements(By.CssSelector("span[class$='select-box--lang mr-2'] div li[class*='nav-item'] a"));
        private IWebElement currencyBox => Page.FindElement(By.CssSelector("span[class = 'd-none d-lg-inline-block select-box--currency mr-2'] li[class ='list-select--head']"));
        private IList<IWebElement> currencyList => Page.FindElements(By.CssSelector("span[class = 'd-none d-lg-inline-block select-box--currency mr-2'] div li[class*='nav-item'] a"));
        private IWebElement rightMenuOptionsIcons (string option) => Page.FindElement(By.CssSelector($"li[class ~=mr-3] i[class = '{option}']"));
        private IWebElement TopMenuList(string optionName, int elementOrder = 1) => Page.FindElement(By.XPath($"(//a[contains(text(), '{optionName}')])[{elementOrder}]"));
        #endregion
    }
}
