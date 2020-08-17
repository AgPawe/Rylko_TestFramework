using OpenQA.Selenium;
using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.TestInfrastructure;
using RyłkoWeb_TestFramework.TestInfrastructure.Enums;
using System.Collections.Generic;

namespace RyłkoWeb_TestFramework.Rylko_Pages.RylkoMainPage
{
    internal class TopPanelShoppingSubPage : SeleniumExtensions
    {
        #region Methods
        internal void NavigateToTopPanelShoppingOption(MainPageTopPanelShoppingOption categoryToSelect)
        {
            WaitForElementIsDisplayed(categoryPanel);
            foreach (var category in categoryList)
            {
                if (category.Text.Equals(categoryToSelect.GetDescription()))
                {
                    ClickElement(category);
                    break;
                }
            }
        }
        #endregion

        #region Page elements
        private IWebElement categoryPanel => Page.FindElement(By.XPath("(//ul[@id = 'targetNav'])[2]"));
        private IList<IWebElement> categoryList => categoryPanel.FindElements(By.XPath("(//ul[@id = 'targetNav'])[2]/li/a/span"));
        #endregion
    }
}
