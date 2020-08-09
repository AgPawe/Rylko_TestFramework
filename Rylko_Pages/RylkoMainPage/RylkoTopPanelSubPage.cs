using OpenQA.Selenium;
using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure;
using RyłkoWeb_TestFramework.TestInfrastructure.Enums;
using Shouldly;
using System.Collections.Generic;

namespace RyłkoWeb_TestFramework.Rylko_Pages.Rylko_MainPage
{
    public class RylkoTopPanelSubPage : SeleniumExtensions
    {
        internal void GoToLeftSideOption(MainPageTopPanelOptions option)
        {
            ClickElement(optionFromLeftMenu(option.GetDescription()));
            optionFromLeftMenu(option.GetDescription()).Click();
        }

        internal void GoToRightSideIconsOption(MainPageTopPanelIconsOptions option)
        {
            ClickElement(rightMenuOptionsIcons(option.GetDescription()));
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

        internal void NavigateToLoginPage()
        {
            ClickElement(loginButtonTopPanel);
        }

        internal void GoToCategory(TopPanelCategories categoryToSelect)
        {
            WaitForElementIsDisplayed(categoryPanel);
             foreach(var category in categoryList)
            {
                if (category.Text.Equals(categoryToSelect.GetDescription()))
                {
                    ClickElement(category);
                    break;
                }
            }
        }

        
        #region Objects
        private IWebElement optionFromLeftMenu(string option) 
            => Page.FindElement(By.XPath($"//p[contains(@class, 'd-inline text-uppercase')]/a[contains(text(), '{option}')]"));

        private IWebElement languageBox => Page.FindElement(By.CssSelector("span[class$='select-box--lang mr-2'] li[class ='list-select--head']"));
        private IList<IWebElement> languagesList => Page.FindElements(By.CssSelector("span[class$='select-box--lang mr-2'] div li[class*='nav-item'] a"));
        private IWebElement currencyBox => Page.FindElement(By.CssSelector("span[class = 'd-none d-lg-inline-block select-box--currency mr-2'] li[class ='list-select--head']"));
        private IList<IWebElement> currencyList => Page.FindElements(By.CssSelector("span[class = 'd-none d-lg-inline-block select-box--currency mr-2'] div li[class*='nav-item'] a"));
        private IWebElement rightMenuOptionsIcons (string option) => Page.FindElement(By.CssSelector($"li[class ~=mr-3] i[class = '{option}']"));
        private IWebElement loginButtonTopPanel => Page.FindElement(By.CssSelector("div> ul li.nav-item.mr-3 a[href='/pl/access/login']"));
        private IWebElement categoryPanel => Page.FindElement(By.CssSelector("#app > div.header-wrapper > div.container-fluid.main-menu"));
        private IList<IWebElement> categoryList => categoryPanel.FindElements(By.CssSelector("a > span"));
        #endregion
    }
}
