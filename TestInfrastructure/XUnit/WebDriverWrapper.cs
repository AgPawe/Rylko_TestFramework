using OpenQA.Selenium;

namespace RyłkoWeb_TestFramework.TestInfrastructure.XUnit
{
    public class WebDriverWrapper
    {
        static WebDriverInitialize WebDriverInitialize = new WebDriverInitialize();

        public static IWebDriver Driver()
        {
            return WebDriverInitialize.driver;
        }

        public static IWebDriver Page => Driver();
    }
}
