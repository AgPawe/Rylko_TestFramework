using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RyłkoWeb_TestFramework.TestInfrastructure.XUnit;
using Shouldly;
using System;

namespace RyłkoWeb_TestFramework.TestInfrastructure
{
    public class SeleniumExtensions : WebDriverWrapper
    {
        #region Methods
        protected void WaitForPageLoaded(string url = "https://www.rylko.com/", int? secondToWait = null)
        {
            WebDriverWait wait = new WebDriverWait(Page, TimeSpan.FromSeconds(secondToWait ?? 10));
            wait.Until(ExpectedConditions.UrlContains(url));
         }

         protected void WaitForElementClickable(IWebElement element, int? secondToWait = null)
         {
            WebDriverWait wait = new WebDriverWait(Page, TimeSpan.FromSeconds(secondToWait ?? 10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
         }

         protected void WaitForElementNotExists(IWebElement element, int? secondToWait = null)
         {
            WebDriverWait wait = new WebDriverWait(Page, TimeSpan.FromSeconds(secondToWait ?? 10));
            wait.Until(ExpectedConditions.StalenessOf(element));
         }

         protected void WaitForElementIsDisplayed(IWebElement element, int? secondToWait = null, bool isDisplayed = true)
         {
            WebDriverWait wait = new WebDriverWait(Page, TimeSpan.FromSeconds(secondToWait ?? 10));

            if (isDisplayed)
                wait.Until(condition => element.Displayed);
            else
                wait.Until(condition => element.Displayed == false);
         }

         protected void ClickElement(IWebElement element)
         {
            WaitForElementClickable(element);
            element.Click(); 
         }

         protected void VerifyAlertText(string alertText, bool acceptAlert = true)
         {
            IAlert alert = Page.SwitchTo().Alert();
            alert.Text.Equals(alertText);

            if (acceptAlert)
                alert.Accept();
            else
                alert.Dismiss();
         }

         protected void VerifyAlertMessage(string alertText)
         {
            WaitForElementIsDisplayed(alertPanel);
            alertPanel.Text.ShouldBe(alertText.ToUpper());
            alertCloseButton.Click();
         }
        #endregion

        #region Alerts elements
        private IWebElement alertPanel => Page.FindElement(By.CssSelector(".container div[role='alert'] span"));
        private IWebElement alertCloseButton => Page.FindElement(By.CssSelector(".container div[role='alert'] button[class='close']"));
        #endregion
    }
}

