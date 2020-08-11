using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RyłkoWeb_TestFramework.TestInfrastructure.XUnit;
using System;

namespace RyłkoWeb_TestFramework.TestInfrastructure
{
    public class SeleniumExtensions : WebDriverWrapper
    {
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

            public void ClickElement(IWebElement element)
            {
                WaitForElementClickable(element);
                element.Click();

                try
                {
                    WaitForElementIsDisplayed(element);
                }
                catch (NoSuchElementException)
                {
                    WaitForElementIsDisplayed(element, isDisplayed: false);
                }
                catch (StaleElementReferenceException)
                {
                    WaitForElementNotExists(element);
                }
            }

            public void VerifyAlertText(string alertText, bool acceptAlert = true)
            {
                IAlert alert = Page.SwitchTo().Alert();
                alert.Text.Equals(alertText);

                if (acceptAlert)
                    alert.Accept();
                else
                    alert.Dismiss();

            }
       }
   }

